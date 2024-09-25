using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class LeaveTypeAddCommandHandler : IRequestHandler<LeaveTypeAddCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public LeaveTypeAddCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(LeaveTypeAddCommand request, CancellationToken cancellationToken)
        {
            var addedType = _mapper.Map<LeaveType>(request.leaveTypeDto);
            addedType = await _leaveTypeRepository.Add(addedType);
            return addedType.Id;
        }
    }
}
