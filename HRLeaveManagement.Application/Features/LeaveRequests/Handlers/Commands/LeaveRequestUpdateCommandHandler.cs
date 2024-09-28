using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class LeaveRequestUpdateCommandHandler : IRequestHandler<LeaveRequestUpdateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaveRequestUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;

            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(LeaveRequestUpdateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.leaveRequestDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveRequest = await _unitOfWork.LeaveRequestRepository.GetById(request.Id);

            if (request.leaveRequestDto is not null)
            {
                _mapper.Map(request.leaveRequestDto, leaveRequest);
                await _unitOfWork.LeaveRequestRepository.Update(leaveRequest);
            }
            else if (request.changeLeaveRequestApprovalDto is not null)
            {
                await _unitOfWork.LeaveRequestRepository
                    .ChangeAprovalStatus(leaveRequest, request.changeLeaveRequestApprovalDto.Approved);
            }
            return Unit.Value;

        }
    }
}
