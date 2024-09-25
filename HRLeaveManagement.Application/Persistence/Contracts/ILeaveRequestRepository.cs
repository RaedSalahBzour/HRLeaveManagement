﻿using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestDetails(int id);
        Task ChangeAprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
    }
}
