using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SpyStore.Mvc.Validation
{
    public class MustBeGreaterThanZeroAttribute : ValidationAttribute, IClientModelValidator
    {
        public MustBeGreaterThanZeroAttribute() : this("{0} must be greater than 0") { }
        public MustBeGreaterThanZeroAttribute(string errorMessage) : base(errorMessage) { }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!int.TryParse(value.ToString(), out int result))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            if (result > 0)
            {
                return ValidationResult.Success;
            };
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            string propertyDisplayName =
                context.ModelMetadata.DisplayName ?? context.ModelMetadata.PropertyName;
            string errorMessage = FormatErrorMessage(propertyDisplayName);
            context.Attributes.Add("data-val-greaterthanzero", errorMessage);
        }
    }
}
