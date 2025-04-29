namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    // Application/Products/Commands/DeleteProductCommand.cs
    using MediatR;
    public record DeleteProductCommand(int Id) : IRequest<bool>;

}
