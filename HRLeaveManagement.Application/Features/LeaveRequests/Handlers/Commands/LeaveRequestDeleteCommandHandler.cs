using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class LeaveRequestDeleteCommandHandler : IRequestHandler<LeaveRequestDeleteCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public LeaveRequestDeleteCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task Handle(LeaveRequestDeleteCommand request, CancellationToken cancellationToken)
        {
            var leaveRequset = await _leaveRequestRepository.GetById(request.Id);
            await _leaveRequestRepository.Delete(leaveRequset);

        }
    }
}
