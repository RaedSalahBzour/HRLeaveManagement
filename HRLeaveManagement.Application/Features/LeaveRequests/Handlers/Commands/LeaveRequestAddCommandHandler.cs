using AutoMapper;
using HRLeaveManagement.Application.Contracts.Infrastructure;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Models;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class LeaveRequestAddCommandHandler : IRequestHandler<LeaveRequestAddCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        public LeaveRequestAddCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
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


                var email = new Email
                {
                    To = "emailAddress",
                    Body = $"Your leave request for {request.leaveRequestDto.StartDate:D} to {request.leaveRequestDto.EndDate:D} " +
                    $"has been submitted successfully.",
                    Subject = "Leave Request Submitted"
                };
                try
                {

                    await _emailSender.SendEmail(email);
                }
                catch (Exception ex)
                {
                    //// Log or handle error, but don't throw...
                }
            }
            return response;
        }
    }
}
