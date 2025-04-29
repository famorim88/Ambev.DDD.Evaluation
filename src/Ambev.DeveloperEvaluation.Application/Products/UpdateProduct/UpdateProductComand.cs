namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    // Application/Products/Commands/UpdateProductCommand.cs
    using MediatR;
    public record UpdateProductCommand(int Id, ProductDto Product) : IRequest<ProductDto>;

}
