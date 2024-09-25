using HRLeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailQuery : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
