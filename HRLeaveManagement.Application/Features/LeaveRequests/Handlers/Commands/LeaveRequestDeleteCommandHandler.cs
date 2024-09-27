using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
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
            if (leaveRequset == null) { throw new NotFoundException(nameof(LeaveRequest), request.Id); };
            await _leaveRequestRepository.Delete(leaveRequset);

        }
    }
}
