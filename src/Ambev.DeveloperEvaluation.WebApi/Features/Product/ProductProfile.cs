using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
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
