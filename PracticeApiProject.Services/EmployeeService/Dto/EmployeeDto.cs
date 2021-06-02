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
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
