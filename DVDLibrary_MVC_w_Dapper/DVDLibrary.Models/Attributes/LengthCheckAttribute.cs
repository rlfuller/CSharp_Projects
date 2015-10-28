using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Attributes
{
    public class LengthCheckAttribute : ValidationAttribute
    {

        private const string DefaultErrorMessage = "  *Must be 90 characters or less";
        //private const string RequiredErrorMessage = "  * This is a required field";

        //do this function in order to have the default custom error messages
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //we are allowing nulls for directors
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value.ToString().Length > 90)
            {
                return new ValidationResult(DefaultErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
