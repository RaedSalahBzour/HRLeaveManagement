using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class LeaveAllocationUpdateCommand : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto updateLeaveAllocationDto { get; set; }
    }
}
