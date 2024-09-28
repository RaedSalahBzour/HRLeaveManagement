using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveType.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;


namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class LeaveTypeUpdateCommandHandler : IRequestHandler<LeaveTypeUpdateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaveTypeUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(LeaveTypeUpdateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.leaveTypeDto);

            if (validationResult.IsValid == false) { throw new ValidationException(validationResult); }

            var leaveType = await _unitOfWork.LeaveTypeRepository.GetById(request.leaveTypeDto.Id);
            _mapper.Map(request.leaveTypeDto, leaveType);
            await _unitOfWork.LeaveTypeRepository.Update(leaveType);
            return Unit.Value;

        }
    }
}
