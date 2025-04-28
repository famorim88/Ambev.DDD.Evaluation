using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branch.GetAll
{
    public record GetAllBranchesQuery() : IRequest<List<GetAllBranchesResult>>;
}
