using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllAsync();
        Task<Sales> GetByIdAsync(string id);
        Task CreateAsync(Cart cart);
        Task AddSaleItemAsync(string id, SaleItem saleItem);

        Task UpdateAsync(Cart sale);
        Task DeleteAsync(string id);
    }
}
