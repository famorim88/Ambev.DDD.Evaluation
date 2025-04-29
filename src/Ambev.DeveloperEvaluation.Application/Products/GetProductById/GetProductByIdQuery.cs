namespace Ambev.DeveloperEvaluation.Application.Products.GetProductById;
using MediatR;
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;

}
