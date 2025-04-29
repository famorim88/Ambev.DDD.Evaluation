namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
public record GetProductsQuery(int Page, int Size, string? OrderBy) : IRequest<List<Product>>;
