namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProducts
{
    using MediatR;
    using Ambev.DeveloperEvaluation.WebApi.Common;

    public record GetProductsQuery(QueryParamsDto QueryParams) : IRequest<PaginatedList<ProductDto>>;

}
