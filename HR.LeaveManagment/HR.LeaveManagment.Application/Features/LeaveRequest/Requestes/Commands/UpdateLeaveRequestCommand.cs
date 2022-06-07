using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public LeaveRequestDto LeaveRequestDto { get; set; }
        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }
    }
}
