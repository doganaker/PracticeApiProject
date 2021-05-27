using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApiProject.Services.EmployeeService.Dto
{
    public class EmployeeDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public bool isDeleted { get; set; }
    }
}
