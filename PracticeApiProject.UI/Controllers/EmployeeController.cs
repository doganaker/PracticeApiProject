using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet(nameof(Index))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "User")]
        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();

            return Ok(employees);
        }

        [HttpPost(nameof(AddEmployee))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "Admin")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //Employee employee = _mapper.Map<Employee>(employeeDto);

                _employeeService.AddEmployee(employee);

                //User.Claims.FirstOrDefault(x => x.Type == "UserId")
                
                return Ok(employee);
            }

            return BadRequest(ModelState);
        }
    }
}
