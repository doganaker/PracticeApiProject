using PracticeApiProject.Services.EmployeeService.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApiProject.Services.EmployeeService.Dto
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [EmailValidation(allowedDomain: "t.com", ErrorMessage = "domain must be t.com")]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
