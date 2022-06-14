using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagment.Application.Features.LeaveAllocation.Requestes.Commands;
using HR.LeaveManagment.Application.Contracts.Persistence;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveAllocation.Handlers.Commands
{
    internal class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "not ok";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var obj = _mapper.Map<HR.LeaveManagement.Domain.LeaveAllocation>(request);
            obj = await _leaveAllocationRepository.Add(obj);

            response.Success = true;
            response.Message = "ok";
            response.Id = obj.Id;

            return response;  
        }
    }
}
