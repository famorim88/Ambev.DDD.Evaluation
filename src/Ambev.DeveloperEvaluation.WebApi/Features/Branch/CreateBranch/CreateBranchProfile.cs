using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.Application.Branch.CreateBranch;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branch.CreateBranch
{
    public class CreateBranchProfile : Profile
    {
        public CreateBranchProfile() 
        {
            CreateMap<CreateBranchCommand, Domain.Entities.Branch>();
            CreateMap<Domain.Entities.Branch,CreateBranchResult>();
        }
    }
}
