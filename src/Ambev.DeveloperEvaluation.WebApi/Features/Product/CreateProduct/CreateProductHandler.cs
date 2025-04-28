using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct
{
    using MediatR;
    using Domain.Entities;
    using Ambev.DeveloperEvaluation.ORM;
    using AutoMapper;
    using Ambev.DeveloperEvaluation.Domain.Repositories;

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;


        public CreateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request);

           await _repository.AddAsync(entity);

            return new ProductDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Price = entity.Price,
                Description = entity.Description,
                Category = entity.Category,
                Image = entity.Image,
                Rate = entity.Rating?.Rate,
                Count = entity.Rating?.Count
            };
        }
    }

}
