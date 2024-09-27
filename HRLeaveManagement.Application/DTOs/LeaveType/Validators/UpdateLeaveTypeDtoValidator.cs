using FluentValidation;

namespace HRLeaveManagement.Application.DTOs.LeaveType.Validators
{

    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {

        public UpdateLeaveTypeDtoValidator()
        {
            // Pass the leaveTypeRepository to ILeaveAllocationDtoValidator's constructor
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }

}
