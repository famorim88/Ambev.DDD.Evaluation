using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, Cart>
    {
        private readonly ISaleRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBranchRepository _branchRepository;

        public UpdateCartHandler(ISaleRepository repository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
        public async Task<Cart> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
        {
            var cart = _repository.GetCartByUserId(command.userId);
            foreach (var item in command.items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                item.HandleTotal(product.Price);
                await _repository.UpateSaleItemAsync(item);
            }
            cart.SaleItems = command.items;
            if(command.finish)
            {
                var user = await _userRepository.GetByIdAsync(new Guid(command.userId));
                var branch = await _branchRepository.GetByIdAsync(cart.BranchId);
                var sale = new Sales
                {
                    Date = DateTime.UtcNow,
                    Customer = new Customer(user.Id.ToString(), user.Username),
                    Branch = branch,
                    Items = command.items,

                };
                sale.HandleTotalAmount();
                await _repository.CreateAsync(sale);
            }
            return cart;
        }
    }
}
