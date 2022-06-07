using AutoMapper;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Commands;
using HR.LeaveManagment.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;   
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveReq = _mapper.Map<LeaveManagement.Domain.LeaveRequest>(request);
            leaveReq = await _leaveRequestRepository.Add(leaveReq);
            return leaveReq.Id;
        }
    }
}
