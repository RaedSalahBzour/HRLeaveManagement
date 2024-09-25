using HRLeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class LeaveTypeAddCommand : IRequest<int>
    {
        public LeaveTypeDto leaveTypeDto { get; set; }
    }
}
