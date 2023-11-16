// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - MustNotBeGreaterThanAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Validation;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class MustNotBeGreaterThanAttribute : ValidationAttribute, IClientModelValidator
{
    readonly string _otherPropertyName;
    string _otherPropertyDisplayName;
    readonly string _prefix;
    public MustNotBeGreaterThanAttribute(string otherPropertyName, string prefix = "")
        : this(otherPropertyName, "{0} must not be greater than {1}", prefix) { }
    public MustNotBeGreaterThanAttribute(string otherPropertyName, string errorMessage, string prefix)
        : base(errorMessage)
    {
        _otherPropertyName = otherPropertyName;
        _otherPropertyDisplayName = otherPropertyName;
        _prefix = prefix;
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name, _otherPropertyDisplayName);
    }
    internal void SetOtherPropertyName(PropertyInfo otherPropertyInfo)
    {
        var displayAttribute = otherPropertyInfo.GetCustomAttributes<DisplayAttribute>().FirstOrDefault();
        if (displayAttribute?.Name != null)
        {
            _otherPropertyDisplayName = displayAttribute.Name;
            return;
        }
        var displayNameAttribute = otherPropertyInfo.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault();
        if (displayNameAttribute?.DisplayName != null)
        {
            _otherPropertyDisplayName = displayNameAttribute.DisplayName;
            return;
        }
        _otherPropertyDisplayName = _otherPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherPropertyName);
        if (otherPropertyInfo == null)
        {
            return new ValidationResult("Unable to validate property. Please contact support");
        }
        SetOtherPropertyName(otherPropertyInfo);
        if (value is not int intValue)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        var otherPropObjectValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        if (otherPropObjectValue is not int otherValue)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return intValue > otherValue 
            ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) 
            : ValidationResult.Success;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        string propertyDisplayName = context.ModelMetadata.GetDisplayName();
        var propertyInfo = context.ModelMetadata.ContainerType.GetProperty(_otherPropertyName);
        SetOtherPropertyName(propertyInfo);
        string errorMessage = FormatErrorMessage(propertyDisplayName);
        context.Attributes.Add("data-val-notgreaterthan", errorMessage);
        context.Attributes.Add("data-val-notgreaterthan-otherpropertyname", _otherPropertyName);
        context.Attributes.Add("data-val-notgreaterthan-prefix", _prefix);
    }
}