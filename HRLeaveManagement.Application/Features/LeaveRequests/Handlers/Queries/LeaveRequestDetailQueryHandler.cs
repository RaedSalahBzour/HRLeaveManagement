using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class LeaveRequestDetailQueryHandler : IRequestHandler<LeaveRequestDetailQuery, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public LeaveRequestDetailQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(LeaveRequestDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestDetails(request.Id);
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}
