using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class LeaveAllocationListQuery : IRequest<LeaveAllocationDto>
    {
    }
}
