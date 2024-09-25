using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class LeaveAllocationDetailQuery : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
