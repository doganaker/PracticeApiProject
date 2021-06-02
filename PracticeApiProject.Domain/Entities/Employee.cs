using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApiProject.Domain.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
