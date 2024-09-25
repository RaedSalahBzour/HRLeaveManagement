using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class LeaveAllocationUpdateCommandHandler : IRequestHandler<LeaveAllocationUpdateCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public LeaveAllocationUpdateCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(LeaveAllocationUpdateCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetById(request.leaveAllocationDto.Id);
            _mapper.Map(request.leaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
