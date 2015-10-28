using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Attributes
{
    class LongerLengthCheckAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "  *Must be 140 characters or less";
        private const string RequiredErrorMessage = "  * This is a required field";

        //do this function in order to have the default custom error messages
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(RequiredErrorMessage);
            }

            if (value.ToString().Length > 1000)
            {
                return new ValidationResult(DefaultErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
