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
    internal class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<HR.LeaveManagement.Domain.LeaveAllocation>(request);
            obj = await _leaveAllocationRepository.Add(obj);  
            return obj.Id;  
        }
    }
}
