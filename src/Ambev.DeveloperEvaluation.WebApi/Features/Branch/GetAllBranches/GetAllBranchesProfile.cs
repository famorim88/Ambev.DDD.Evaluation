using Ambev.DeveloperEvaluation.Application.Branch.GetAll;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branch.GetAllBranches
{
    public class GetAllBranchesProfile: Profile
    {
        public GetAllBranchesProfile() 
        {
            CreateMap<Domain.Entities.Branch, GetAllBranchesResult>();
        }
    }
}
