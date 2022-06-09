using FluentValidation;
using HR.LeaveManagment.Application.Persistence.Contracts;


namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private ILeaveAllocationRepository _repo;

        public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository repo)
        {
            _repo = repo;
            Include(new ILeaveAllocationDtoValidator(_repo));
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present.");

        }
    }
}
