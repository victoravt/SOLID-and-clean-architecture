﻿using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto LeaveReqeustDto { get; set; }
    }
}
