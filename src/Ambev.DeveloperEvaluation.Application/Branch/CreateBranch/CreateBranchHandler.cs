using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branch.CreateBranch
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, Domain.Entities.Branch>
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;
        public CreateBranchHandler(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Domain.Entities.Branch> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {

            var exists = await _repository.GetByNameAsync(command.Name);
            if (exists != null)
                throw new InvalidOperationException($"Branch {command.Name} already exists");

            var branch = _mapper.Map<Domain.Entities.Branch>(command);

            return await _repository.AddAsync(branch); ;
        }
    }
}
