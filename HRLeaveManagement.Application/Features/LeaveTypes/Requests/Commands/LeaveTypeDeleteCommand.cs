using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class LeaveTypeDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
