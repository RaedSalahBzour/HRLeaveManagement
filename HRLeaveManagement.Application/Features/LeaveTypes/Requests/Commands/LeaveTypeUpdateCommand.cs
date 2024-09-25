using HRLeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class LeaveTypeUpdateCommand : IRequest<Unit>
    {
        public LeaveTypeDto leaveTypeDto { get; set; }
    }
}
