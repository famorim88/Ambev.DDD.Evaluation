namespace Ambev.DeveloperEvaluation.Application.Products.GetProductById;

using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
