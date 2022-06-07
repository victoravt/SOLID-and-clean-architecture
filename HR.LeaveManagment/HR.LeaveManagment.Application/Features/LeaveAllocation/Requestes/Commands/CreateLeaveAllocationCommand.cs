using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveAllocation.Requestes.Commands
{
    internal class CreateLeaveAllocationCommand : IRequest<int>
    {
        public LeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
