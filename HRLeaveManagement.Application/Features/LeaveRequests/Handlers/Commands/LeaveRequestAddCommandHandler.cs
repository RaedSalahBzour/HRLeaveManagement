using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class LeaveRequestAddCommandHandler : IRequestHandler<LeaveRequestAddCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public LeaveRequestAddCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(LeaveRequestAddCommand request, CancellationToken cancellationToken)
        {
            var addedRequest = _mapper.Map<LeaveRequest>(request.leaveRequestDto);
            addedRequest = await _leaveRequestRepository.Add(addedRequest);
            return addedRequest.Id;
        }
    }
}
