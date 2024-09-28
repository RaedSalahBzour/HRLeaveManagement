using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class LeaveAllocationDeleteCommandHandler : IRequestHandler<LeaveAllocationDeleteCommand>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveAllocationDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(LeaveAllocationDeleteCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.GetById(request.Id);
            if (leaveAllocation == null) { throw new NotFoundException(nameof(LeaveAllocation), request.Id); };
            await _unitOfWork.LeaveAllocationRepository.Delete(leaveAllocation);

        }
    }
}
