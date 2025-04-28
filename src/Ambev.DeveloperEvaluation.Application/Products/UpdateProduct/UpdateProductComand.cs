namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct
{
    // Application/Products/Commands/UpdateProductCommand.cs
    using MediatR;
    public record UpdateProductCommand(int Id, ProductDto Product) : IRequest<ProductDto>;

}
