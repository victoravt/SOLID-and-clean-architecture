using HR.LeaveManagment.Application.DTOs;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveAllocation.Requestes.Queries
{
    public class GetLeaveAllocationRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
