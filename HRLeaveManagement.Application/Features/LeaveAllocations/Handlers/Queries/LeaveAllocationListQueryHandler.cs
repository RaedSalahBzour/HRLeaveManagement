using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class LeaveAllocationListQueryHandler :
        IRequestHandler<LeaveAllocationListQuery, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public LeaveAllocationListQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(LeaveAllocationListQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocatios = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
            return _mapper.Map<LeaveAllocationDto>(leaveAllocatios);
        }
    }
}
