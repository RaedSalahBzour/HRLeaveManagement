﻿namespace HRLeaveManagement.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto
    {
        public int LeaveTypeId { get; set; }
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
    }
}