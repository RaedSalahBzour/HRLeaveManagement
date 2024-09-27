using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Responses;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class LeaveTypeAddCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto leaveTypeDto { get; set; }
    }
}
