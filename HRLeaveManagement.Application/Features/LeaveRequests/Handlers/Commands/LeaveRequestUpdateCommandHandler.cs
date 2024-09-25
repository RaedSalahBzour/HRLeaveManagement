using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class LeaveRequestUpdateCommandHandler : IRequestHandler<LeaveRequestUpdateCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public LeaveRequestUpdateCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(LeaveRequestUpdateCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetById(request.Id);

            if (request.leaveRequestDto is not null)
            {
                _mapper.Map(request.leaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.changeLeaveRequestApprovalDto is not null)
            {
                await _leaveRequestRepository
                    .ChangeAprovalStatus(leaveRequest, request.changeLeaveRequestApprovalDto.Approved);
            }
            return Unit.Value;

        }
    }
}
