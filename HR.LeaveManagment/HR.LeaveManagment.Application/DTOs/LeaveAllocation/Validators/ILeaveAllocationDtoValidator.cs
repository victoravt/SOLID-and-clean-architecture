using FluentValidation;
using HR.LeaveManagment.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private ILeaveAllocationRepository _repo;

        public ILeaveAllocationDtoValidator(ILeaveAllocationRepository repo)
        {
            _repo = repo;

            RuleFor(x => x.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(x => x.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (x, t) =>
                {
                    var exists = await _repo.Exists(x);
                    return !exists;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
