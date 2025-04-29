namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    using MediatR;
    public record CreateProductCommand(ProductDto Product) : IRequest<ProductDto>;

}
