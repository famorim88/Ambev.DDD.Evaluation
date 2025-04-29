using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    public class GetProductsQueryHandler:IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;


        public GetProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = (await _repository.GetAllAsync()).Skip((request.Page - 1) * request.Size).Take(request.Size);
            if (!string.IsNullOrEmpty(request.OrderBy))
            {
                var orders = request.OrderBy.Split(',');
                foreach (var order in orders)
                {
                    var trimmed = order.Trim();
                    if (trimmed.EndsWith(" desc"))
                        query = query.OrderByDescending(e => EF.Property<object>(e, trimmed.Replace(" desc", "")));
                    else
                        query = query.OrderBy(e => EF.Property<object>(e, trimmed));
                }
            }
            return query.ToList();
        }
    }
}
