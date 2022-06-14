using AutoMapper;
using HR.LeaveManagment.Application.DTOs;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Features.LeaveAllocation.Requestes.Queries;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;

        public GetLeaveAllocationListHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var list = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();
            return _mapper.Map<List<LeaveAllocationDto>>(list);
        }
    }
}
