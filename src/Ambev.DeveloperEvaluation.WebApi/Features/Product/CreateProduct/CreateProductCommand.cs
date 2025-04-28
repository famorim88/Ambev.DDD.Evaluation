namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct
{
    using MediatR;
    public record CreateProductCommand(ProductDto Product) : IRequest<ProductDto>;

}
