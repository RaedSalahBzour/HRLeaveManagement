using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class LeaveRequestDeleteCommandHandler : IRequestHandler<LeaveRequestDeleteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaveRequestDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(LeaveRequestDeleteCommand request, CancellationToken cancellationToken)
        {
            var leaveRequset = await _unitOfWork.LeaveRequestRepository.GetById(request.Id);
            if (leaveRequset == null) { throw new NotFoundException(nameof(LeaveRequest), request.Id); };
            await _unitOfWork.LeaveRequestRepository.Delete(leaveRequset);

        }
    }
}
