// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - MustBeGreaterThanZeroAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Services.Validation;

[AttributeUsage(AttributeTargets.Property)]
public class MustBeGreaterThanZeroAttribute : ValidationAttribute, IClientModelValidator
{
    public MustBeGreaterThanZeroAttribute() : this("{0} must be greater than 0")
    {
    }

    public MustBeGreaterThanZeroAttribute(string errorMessage) : base(errorMessage)
    {
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name);
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        string propertyDisplayName =
            context.ModelMetadata.DisplayName ?? context.ModelMetadata.PropertyName;
        string errorMessage = FormatErrorMessage(propertyDisplayName);
        context.Attributes.Add("data-val-greaterthanzero", errorMessage);
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (!int.TryParse(value.ToString(), out int result))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return result > 0 ? ValidationResult.Success : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
}