using FluentValidation;
using HR.LeaveManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private ILeaveAllocationRepository _repo;

        public CreateLeaveAllocationDtoValidator(ILeaveAllocationRepository repo)
        {
            _repo = repo;
            Include(new ILeaveAllocationDtoValidator(_repo));


        }
    }
}
