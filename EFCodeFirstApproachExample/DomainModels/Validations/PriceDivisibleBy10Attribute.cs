using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Validations
{
    public class PriceDivisibleBy10Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((Convert.ToDecimal(value) % 10) == 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}