using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class LeaveTypeDeleteCommandHandler : IRequestHandler<LeaveRequestDeleteCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public LeaveTypeDeleteCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task Handle(LeaveRequestDeleteCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetById(request.Id);
            await _leaveTypeRepository.Delete(leaveType);

        }
    }
}
