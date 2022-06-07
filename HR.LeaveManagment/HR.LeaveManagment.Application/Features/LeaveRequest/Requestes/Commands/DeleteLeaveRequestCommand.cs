using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Commands
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }

    }
}
