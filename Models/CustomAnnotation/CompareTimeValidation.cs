using System.ComponentModel.DataAnnotations;

namespace BadmintonHubWeb.Models.CustomAnnotation
{
    public class CompareTimeValidation : ValidationAttribute
    {
        private readonly string _startTimeProperty;
        public CompareTimeValidation(string startTimeProperty)
        {
            _startTimeProperty = startTimeProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // if value is null or empty => return success (because [Required] attrribute will handle it)
            if (value is not string endTimeStr || !TimeSpan.TryParse(endTimeStr, out var endTime))
            {
                return ValidationResult.Success;
            }

            var startTimeProperty = validationContext.ObjectType.GetProperty(_startTimeProperty);
            if (startTimeProperty?.GetValue(validationContext.ObjectInstance) is not string startTimeStr
                || !TimeSpan.TryParse(startTimeStr, out var startTime))
            {
                return ValidationResult.Success;
            }

            if (endTime < startTime)
            {
                return new ValidationResult("End time must be after start time.");
            }

            return (endTime - startTime).TotalMinutes >= 60
                ? ValidationResult.Success
                : new ValidationResult("End time must be at least 1 hour after start time.");
        }
    }
}
