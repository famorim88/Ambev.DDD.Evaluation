using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branch.GetAll
{
    public class GetAllBranchesHandler : IRequestHandler<GetAllBranchesQuery,List<GetAllBranchesResult>>
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;
        public GetAllBranchesHandler(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllBranchesResult>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<GetAllBranchesResult>>(await _repository.GetAllAsync());
        }
    }
}
