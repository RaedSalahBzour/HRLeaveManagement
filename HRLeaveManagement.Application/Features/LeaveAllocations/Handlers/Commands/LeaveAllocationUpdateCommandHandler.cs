using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class LeaveAllocationUpdateCommandHandler : IRequestHandler<LeaveAllocationUpdateCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public LeaveAllocationUpdateCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveAllocationDtoValidator leaveTypeDtoValidator, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(LeaveAllocationUpdateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.updateLeaveAllocationDto);
            if (validationResult.IsValid == false) { throw new ValidationException(validationResult); }
            var leaveAllocation = await _leaveAllocationRepository.GetById(request.updateLeaveAllocationDto.Id);
            _mapper.Map(request.updateLeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
