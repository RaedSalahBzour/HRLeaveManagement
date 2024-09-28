using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagment.API.Controllers
{
    public class LeaveAllocationController : Controller
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveAllocations = await _mediator.Send(new LeaveAllocationListQuery());
            return Ok(leaveAllocations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new LeaveAllocationDetailQuery());
            return Ok(leaveAllocation);
        }
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var command = new LeaveAllocationAddCommand { leaveAllocationDto = leaveAllocation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLeaveAllocationDto leaveAllocation)
        {
            var command = new LeaveAllocationUpdateCommand { updateLeaveAllocationDto = leaveAllocation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new LeaveAllocationDeleteCommand { Id = id };
            var response = _mediator.Send(command);
            return Ok(response);
        }
    }
}
