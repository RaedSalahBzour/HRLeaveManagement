using HRLeaveManagement.Application.Persistence.Contracts;
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
