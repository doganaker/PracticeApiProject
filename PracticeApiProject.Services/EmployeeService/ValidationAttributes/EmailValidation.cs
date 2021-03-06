using PracticeApiProject.Services.EmployeeService.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticeApiProject.Services.EmployeeService.ValidationAttributes
{
    public class EmailValidation : ValidationAttribute
    {
        private readonly string allowedDomain;
        public EmailValidation(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (EmployeeDto)validationContext.ObjectInstance;

            if (employee.Email == null)
            {
                return new ValidationResult("Email is required!!!");
            }

            var validEmail = value;
            string[] strings = validEmail.ToString().Split("@");

            return (validEmail.ToString().Contains("@") ? (strings[1].ToUpper() == allowedDomain.ToUpper() ? ValidationResult.Success : new ValidationResult(ErrorMessage)) : new ValidationResult("Please enter in correct email format!!"));
        }
        //public override bool IsValid(object value)
        //{
        //    string[] strings = value.ToString().Split("@");
        //    return strings[1].ToUpper() == allowedDomain.ToUpper();
        //}
    }
}
