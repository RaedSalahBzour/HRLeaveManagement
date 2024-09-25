using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class LeaveRequestAddCommand : IRequest<int>
    {
        public LeaveRequestDto leaveRequestDto { get; set; }
    }
}
