using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Persistence.Reopsitories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HRLeaveManagementDbContext _context;
        public LeaveTypeRepository(HRLeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
