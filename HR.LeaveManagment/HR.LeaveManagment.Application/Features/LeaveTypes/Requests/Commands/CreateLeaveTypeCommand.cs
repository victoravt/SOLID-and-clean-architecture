using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse> 
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
