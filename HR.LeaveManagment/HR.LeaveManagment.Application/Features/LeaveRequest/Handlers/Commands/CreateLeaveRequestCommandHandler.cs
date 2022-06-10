using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagment.Application.Exceptions;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Commands;
using HR.LeaveManagment.Application.Persistence.Contracts;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;   
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveReqeustDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "not ok";
                response.Errors = validationResult.Errors.Select(x=>x.ErrorMessage).ToList();
            }

            response.Success = true;
            response.Message = "ok";

            var leaveReq = _mapper.Map<LeaveManagement.Domain.LeaveRequest>(request);
            leaveReq = await _leaveRequestRepository.Add(leaveReq);
            response.Id = leaveReq.Id;

            return response;
        }
    }
}
