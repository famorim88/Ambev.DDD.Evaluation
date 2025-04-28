namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProductById
{
    using MediatR;
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;

}
