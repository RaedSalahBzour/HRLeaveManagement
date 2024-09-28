using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class LeaveTypeDeleteCommandHandler : IRequestHandler<LeaveRequestDeleteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaveTypeDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(LeaveRequestDeleteCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _unitOfWork.LeaveTypeRepository.GetById(request.Id);
            if (leaveType == null) { throw new NotFoundException(nameof(LeaveType), request.Id); };
            await _unitOfWork.LeaveTypeRepository.Delete(leaveType);

        }
    }
}
