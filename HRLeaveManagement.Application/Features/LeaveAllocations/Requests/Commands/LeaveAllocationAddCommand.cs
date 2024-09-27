using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Responses;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class LeaveAllocationAddCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto leaveAllocationDto { get; set; }

    }
}
