using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class LeaveRequestAddCommandHandler : IRequestHandler<LeaveRequestAddCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public LeaveRequestAddCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(LeaveRequestAddCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var vaildator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await vaildator.ValidateAsync(request.leaveRequestDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var addedRequest = _mapper.Map<LeaveRequest>(request.leaveRequestDto);
                addedRequest = await _leaveRequestRepository.Add(addedRequest);
                response.Success = true;
                response.Message = "Request Created Successfully";
                response.Id = addedRequest.Id;
            }
            return response;
        }
    }
}
