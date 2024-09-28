using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagment.API.Controllers
{
    public class LeaveRequestController : Controller
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveRequests = await _mediator.Send(new LeaveRequestListQuery());
            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new LeaveRequestDetailQuery());
            return Ok(leaveRequest);
        }
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CreateLeaveRequestDto leaveRequest)
        {
            var command = new LeaveRequestAddCommand { leaveRequestDto = leaveRequest };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
        {
            var command = new LeaveRequestUpdateCommand { leaveRequestDto = leaveRequest };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("changeapproval")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromBody] ChangeLeaveRequestApprovalDto approvalDto)
        {
            var command = new LeaveRequestUpdateCommand { changeLeaveRequestApprovalDto = approvalDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new LeaveRequestDeleteCommand { Id = id };
            var response = _mediator.Send(command);
            return Ok(response);
        }
    }
}
