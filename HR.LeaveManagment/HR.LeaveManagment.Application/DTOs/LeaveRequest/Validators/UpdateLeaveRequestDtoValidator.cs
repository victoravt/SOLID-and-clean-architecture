using FluentValidation;
using HR.LeaveManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public ILeaveRequestRepository _repo { get; }

        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository repo)
        {
            _repo = repo;
            Include(new ILeaveRequestDtoValidator(_repo));

            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }

    }
}
