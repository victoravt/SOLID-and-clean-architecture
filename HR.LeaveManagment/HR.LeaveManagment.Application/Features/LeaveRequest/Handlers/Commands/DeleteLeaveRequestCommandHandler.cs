using AutoMapper;
using HR.LeaveManagment.Application.Exceptions;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Commands;
using HR.LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Commands
{
    internal class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveRequestRepository.Get(request.Id);

            if (leaveType == null)
                throw new NotFoundException(nameof(LeaveManagement.Domain.LeaveRequest), request.Id);

            await _leaveRequestRepository.Delete(leaveType);

            return Unit.Value;
        }
    }
}
