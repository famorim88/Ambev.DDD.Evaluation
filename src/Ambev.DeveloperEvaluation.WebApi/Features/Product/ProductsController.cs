// Controllers/ProductsController.cs
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProductById;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.Application.Products;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IRedisCacheService _redisCacheService;
    private readonly string cacheKeyAll = "ProductAll:";
    private readonly string cacheKeyById = "ProductById:";


    public ProductsController(IMediator mediator, IRedisCacheService redisCacheService)
    {
        _mediator = mediator;
        _redisCacheService = redisCacheService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParamsDto queryParams)
    {
        string cacheKey = $"{cacheKeyAll}" +
             $"{queryParams.Page}" +
             $"{queryParams.Size}" +
             $"{queryParams.OrderBy}";

        var cached = await _redisCacheService.GetAsync<PaginatedList<Product>>(cacheKey);
        if ( cached != null )
            return OkPaginated(cached);

        var result = await _mediator.Send(new GetProductsQuery(queryParams.Page,queryParams.Size,queryParams.OrderBy));
        var response = new PaginatedList<Product>(result,result.Count, queryParams.Page, queryParams.Size);
        
        await _redisCacheService.SetAsync(cacheKey, response, TimeSpan.FromMinutes(10));
        return OkPaginated(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        string cacheKey = $"{cacheKeyById}{id}";
        var cached = await _redisCacheService.GetAsync<Product>(cacheKey);
        if (cached != null)
            return Ok(cached);
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        await _redisCacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto product)
    {
        var result = await _mediator.Send(new CreateProductCommand(product));
        await _redisCacheService.RemoveByPrefixAsync("Product");
        return Created("", new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto product)
    {
        var result = await _mediator.Send(new UpdateProductCommand(id, product));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));
        return Ok(result);
    }
}
