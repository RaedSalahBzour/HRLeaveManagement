using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class LeaveAllocationAddCommand : IRequest<int>
    {
        public LeaveAllocationDto leaveAllocationDto { get; set; }

    }
}
