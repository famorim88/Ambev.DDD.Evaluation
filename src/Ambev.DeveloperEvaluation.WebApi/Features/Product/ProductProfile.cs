using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product
{
    public class ProductProfile :Profile
    {
        public ProductProfile() 
        {
            CreateMap<CreateProductCommand, Domain.Entities.Product>();
        }
    }
}
