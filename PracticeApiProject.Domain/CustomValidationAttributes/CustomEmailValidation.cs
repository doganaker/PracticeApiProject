using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticeApiProject.Domain.CustomValidationAttributes
{
    public class CustomEmailValidation : ValidationAttribute
    {
        private readonly string allowedDomain;
        public CustomEmailValidation(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
            string[] strings = value.ToString().Split("@");
            return strings[1].ToUpper() == allowedDomain.ToUpper();
        }
        
    }
}
