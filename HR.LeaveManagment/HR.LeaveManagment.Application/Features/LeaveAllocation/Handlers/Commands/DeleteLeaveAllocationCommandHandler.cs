using AutoMapper;
using HR.LeaveManagment.Application.Features.LeaveAllocation.Requestes.Commands;
using HR.LeaveManagment.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveAllocation.Handlers.Commands
{
    internal class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveAllocationRepository.Get(request.Id);

            await _leaveAllocationRepository.Delete(leaveType);

            return Unit.Value;
        }
    }
}
