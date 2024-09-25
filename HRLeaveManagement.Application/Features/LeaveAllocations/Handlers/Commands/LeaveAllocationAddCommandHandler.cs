using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class LeaveAllocationAddCommandHandler : IRequestHandler<LeaveAllocationAddCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public LeaveAllocationAddCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(LeaveAllocationAddCommand request, CancellationToken cancellationToken)
        {
            var addedAllocation = _mapper.Map<LeaveAllocation>(request.leaveAllocationDto);
            addedAllocation = await _leaveAllocationRepository.Add(addedAllocation);
            return addedAllocation.Id;
        }
    }
}
