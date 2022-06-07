using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Commands
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public LeaveRequestDto LeaveReqeustDto { get; set; }
    }
}
