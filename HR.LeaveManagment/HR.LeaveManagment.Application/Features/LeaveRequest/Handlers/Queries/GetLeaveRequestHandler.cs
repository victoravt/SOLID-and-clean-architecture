using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveRequestDto;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Queries;
using HR.LeaveManagment.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestHandler : IRequestHandler<GetLeaveRequestRequest, LeaveRequestDto>
    {
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;

        public GetLeaveRequestHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }


        public async Task<LeaveRequestDto> Handle(GetLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var obj = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDto>(obj);

        }
    }
}
