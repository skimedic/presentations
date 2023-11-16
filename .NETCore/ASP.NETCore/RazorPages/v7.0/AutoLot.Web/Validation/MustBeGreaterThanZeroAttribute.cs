// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - MustBeGreaterThanZeroAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Validation;

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
        if (value is not int intValue)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return intValue <= 0 ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : ValidationResult.Success;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        string propertyDisplayName = 
            context.ModelMetadata.DisplayName ?? context.ModelMetadata.PropertyName;
        string errorMessage = FormatErrorMessage(propertyDisplayName);
        context.Attributes.Add("data-val-greaterthanzero", errorMessage);
    }
}
