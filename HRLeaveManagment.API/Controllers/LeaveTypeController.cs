using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypeController : Controller
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveTypes = await _mediator.Send(new LeaveTypeListQuery());
            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailQuery());
            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new LeaveTypeAddCommand { leaveTypeDto = leaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LeaveTypeDto leaveType)
        {
            var command = new LeaveTypeUpdateCommand { leaveTypeDto = leaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new LeaveTypeDeleteCommand { Id = id };
            var response = _mediator.Send(command);
            return Ok(response);
        }
    }
}
