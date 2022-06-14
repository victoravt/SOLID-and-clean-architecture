using AutoMapper;
using HR.LeaveManagment.Application.DTOs;
using HR.LeaveManagment.Application.Features.LeaveAllocation.Requestes.Queries;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;

namespace HR.LeaveManagment.Application.Features.LeaveAllocation.Handlers.Queries
{
    internal class GetLeaveAllocationHandler : IRequestHandler<GetLeaveAllocationRequest, LeaveAllocationDto>
    {
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;

        public GetLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;   
        }


        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var obj = await _leaveAllocationRepository.Get(request.Id);
            return _mapper.Map<LeaveAllocationDto>(obj);

        }
    }
}
