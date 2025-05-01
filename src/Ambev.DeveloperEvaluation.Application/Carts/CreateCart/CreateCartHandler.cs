using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartHandler :IRequestHandler<CreateCartCommand, Cart>
    {
        private readonly ISaleRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateCartHandler(ISaleRepository repository, IProductRepository productRepository, IMapper mapper)
        {
            _repository = repository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Cart> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            await _repository.CreateCartAsync(command.Cart);
            foreach (var item in command.Cart.SaleItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                item.HandleTotal(product.Price);
                await _repository.AddSaleItemAsync(item);
            }
            return command.Cart;
        }
    }
}
