using HR.LeaveManagment.Application.DTOs.Common;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using System;


namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
