using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailQueryHanlder : IRequestHandler<GetLeaveTypeDetailQuery, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeDetailQueryHanlder(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetById(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
