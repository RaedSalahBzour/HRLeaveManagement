﻿using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class LeaveAllocationDeleteCommandHandler : IRequestHandler<LeaveAllocationDeleteCommand>

    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public LeaveAllocationDeleteCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task Handle(LeaveAllocationDeleteCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetById(request.Id);
            if (leaveAllocation == null) { throw new NotFoundException(nameof(LeaveAllocation), request.Id); };
            await _leaveAllocationRepository.Delete(leaveAllocation);

        }
    }
}
