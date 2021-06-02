using PracticeApiProject.Domain.Entities;
using PracticeApiProject.Services.EmployeeService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApiProject.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
    }
}
