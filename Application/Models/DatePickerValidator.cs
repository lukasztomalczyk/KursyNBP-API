using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Models
{
    public class DatePickerValidator : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateValidate = (DatePicker)validationContext.ObjectInstance;
            var dateNow = DateTime.Now.AddDays(-2);
            if (dateValidate.FromDate > dateNow && dateValidate.ToDate > dateNow && dateValidate.FromDate == dateValidate.ToDate)
            {
                return new ValidationResult("Podałeś zły zakres dat !");
            }

            return ValidationResult.Success;
        }
    }
}
