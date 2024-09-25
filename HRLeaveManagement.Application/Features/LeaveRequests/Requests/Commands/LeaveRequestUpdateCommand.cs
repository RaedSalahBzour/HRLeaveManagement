using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class LeaveRequestUpdateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public LeaveRequestDto leaveRequestDto { get; set; }
        public ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto { get; set; }
    }
}
