using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Reopsitories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HRLeaveManagementDbContext _context;
        public LeaveAllocationRepository(HRLeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationDetails(int id)
        {
            var LAllocation = await _context.LeaveAllocations.Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return LAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var lAllocations = await _context.LeaveAllocations.Include(q => q.LeaveType)
                .ToListAsync();
            return lAllocations;
        }
    }
}
