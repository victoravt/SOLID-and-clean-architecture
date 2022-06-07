using HR.LeaveManagment.Application.DTOs.Common;


namespace HR.LeaveManagment.Application.DTOs.LeaveType
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
