using Microsoft.AspNetCore.Mvc;
using PracticeApiProject.Domain.Entities;
using PracticeApiProject.Services.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApiProject.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(nameof(Index))]
        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();

            return Json(employees);
        }

        [HttpPost(nameof(AddEmployee))]
        public IActionResult AddEmployee([FromForm] Employee employee)
        {
            _employeeService.AddEmployee(employee);

            return Json(employee);
        }
    }
}
