using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Reopsitories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HRLeaveManagementDbContext _context;
        public LeaveRequestRepository(HRLeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeAprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _context.Entry(leaveRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestDetails(int id)
        {
            var lRequest = await _context.LeaveRequests.Include(q => q.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);
            return lRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var lRequests = await _context.LeaveRequests.Include(x => x.LeaveType).ToListAsync();
            return lRequests;
        }
    }
}
