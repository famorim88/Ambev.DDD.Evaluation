using Ambev.DeveloperEvaluation.Application.Branch.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branch.GetAll;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branch
{
    /// <summary>
    /// Controller for branch operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BranchController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<Domain.Entities.Branch>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] CreateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(new ApiResponseWithData<Domain.Entities.Branch>
                {
                    Success = true,
                    Data = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllBranchesResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllBranchesQuery());

                return Ok(new ApiResponseWithData<List<GetAllBranchesResult>>
                {
                    Success = true,
                    Data = response
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }

}
