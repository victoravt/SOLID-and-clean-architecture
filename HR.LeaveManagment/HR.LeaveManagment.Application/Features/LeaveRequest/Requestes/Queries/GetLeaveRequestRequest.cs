﻿using HR.LeaveManagment.Application.DTOs.LeaveRequestDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Queries
{
    public class GetLeaveRequestRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
