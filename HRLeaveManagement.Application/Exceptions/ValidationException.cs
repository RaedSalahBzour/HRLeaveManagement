using FluentValidation.Results;

namespace HRLeaveManagement.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException(ValidationResult validationResult)
        {
            Errors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}