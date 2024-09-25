using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class LeaveAllocationDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
