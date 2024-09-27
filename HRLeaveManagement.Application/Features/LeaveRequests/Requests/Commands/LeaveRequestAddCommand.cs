using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Responses;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class LeaveRequestAddCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto leaveRequestDto { get; set; }
    }
}
