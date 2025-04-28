namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.DeleteProduct
{
    // Application/Products/Commands/DeleteProductCommand.cs
    using MediatR;
    public record DeleteProductCommand(int Id) : IRequest<bool>;

}
