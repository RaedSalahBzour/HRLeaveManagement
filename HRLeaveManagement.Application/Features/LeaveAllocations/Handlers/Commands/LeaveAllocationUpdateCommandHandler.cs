using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class LeaveAllocationUpdateCommandHandler : IRequestHandler<LeaveAllocationUpdateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaveAllocationUpdateCommandHandler(IMapper mapper,
             IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(LeaveAllocationUpdateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.updateLeaveAllocationDto);
            if (validationResult.IsValid == false) { throw new ValidationException(validationResult); }
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.GetById(request.updateLeaveAllocationDto.Id);
            _mapper.Map(request.updateLeaveAllocationDto, leaveAllocation);
            await _unitOfWork.LeaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
