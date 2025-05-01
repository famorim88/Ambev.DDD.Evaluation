using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MongoContext _context;
        private readonly DefaultContext _defaultContext;


        public SaleRepository(MongoContext context, DefaultContext defaultContext)
        {
            _context = context;
            _defaultContext = defaultContext;
        }
        public async Task<int> GetNextSequenceValue(string counterName)
        {
            var filter = Builders<Counter>.Filter.Eq(c => c.Id, counterName);
            var update = Builders<Counter>.Update.Inc(c => c.SequenceValue, 1);
            var options = new FindOneAndUpdateOptions<Counter> { IsUpsert = true, ReturnDocument = ReturnDocument.After };
            var counter = await _context.Counter.FindOneAndUpdateAsync(filter, update, options);
            return counter.SequenceValue;
        }
        public async Task<List<Sales>> GetAllAsync() =>
           await _context.Sales.Find(_ => true).ToListAsync();

        public async Task<Sales> GetByIdAsync(string id) =>
            await _context.Sales.Find(s => s.Id == new Guid(id)).FirstOrDefaultAsync();

        public async Task CreateCartAsync(Cart cart) => await _defaultContext.Cart.AddAsync(cart);
        public async Task AddSaleItemAsync(SaleItem item) => await _defaultContext.SaleItem.AddAsync(item);
        public async Task UpateSaleItemAsync(SaleItem item)
        {
            _defaultContext.SaleItem.Update(item);
            await _defaultContext.SaveChangesAsync();
        }
        public async Task UpdateCartAsync(Cart cart)
        {
            _defaultContext.Cart.Update(cart);
            await _defaultContext.SaveChangesAsync();
        }
        public Cart GetCartByUserId(string userId)
        {
            return _defaultContext.Cart.FirstOrDefault(s => s.UserId == userId);
        }
        public async Task DeleteCartAsync(string userId)
        {
            var Cart = _defaultContext.Cart.FirstOrDefault(x => x.UserId == userId);
            if (Cart != null)
            {
                _defaultContext.Cart.Remove(Cart);
                await _defaultContext.SaveChangesAsync();
            }
        }
        public async Task CreateAsync(Sales sale)
        {
            sale.SaleNumber = await GetNextSequenceValue("saleid");
            await _context.Sales.InsertOneAsync(sale);
            Console.WriteLine("[Event] SaleCreated: " + sale.SaleNumber);
        }

        public async Task UpdateAsync(Sales sale)
        {
            await _context.Sales.ReplaceOneAsync(s => s.Id == sale.Id, sale);
            Console.WriteLine("[Event] SaleModified: " + sale.SaleNumber);
        }

        public async Task DeleteAsync(string id)
        {
            var sale = await GetByIdAsync(id);
            if (sale != null)
            {
                sale.Cancelled = true;
                await UpdateAsync(sale);
                Console.WriteLine("[Event] SaleCancelled: " + sale.SaleNumber);
            }
        }
    }
}
