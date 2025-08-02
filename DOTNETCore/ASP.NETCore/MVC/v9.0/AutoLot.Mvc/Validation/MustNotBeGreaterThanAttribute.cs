﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Mvc - MustNotBeGreaterThanAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/10/30
// ==================================

namespace AutoLot.Mvc.Validation;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class MustNotBeGreaterThanAttribute : ValidationAttribute, IClientModelValidator
{
    readonly string _otherPropertyName;
    string _otherPropertyDisplayName;
    readonly string _prefix;

    public MustNotBeGreaterThanAttribute(string otherPropertyName, string prefix = "")
        : this(otherPropertyName, "{0} must not be greater than {1}", prefix)
    {
    }

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
        var displayAttribute =
            otherPropertyInfo.GetCustomAttributes<DisplayAttribute>().FirstOrDefault();
        if (displayAttribute != null)
        {
            _otherPropertyDisplayName = displayAttribute.Name;
            return;
        }

        var displayNameAttribute =
            otherPropertyInfo.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault();
        if (displayNameAttribute != null)
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
        if (!int.TryParse(value.ToString(), out int toValidate))
        {
            return new ValidationResult($"{validationContext.DisplayName} must be numeric.");
        }

        var otherPropObjectValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        if (otherPropObjectValue == null || !int.TryParse(otherPropObjectValue.ToString(),
                out var otherValue))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return toValidate > otherValue
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