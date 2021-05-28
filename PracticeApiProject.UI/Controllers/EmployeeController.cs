using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeApiProject.Domain.Entities;
using PracticeApiProject.Services.EmployeeService;
using PracticeApiProject.Services.EmployeeService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();

            return Ok(employees);
        }

        [HttpPost(nameof(AddEmployee))]
        [Authorize(Roles = "Admin")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);

            //User.Claims.FirstOrDefault(x => x.Type == "UserId")

            return Ok(employee);
        }
    }
}
