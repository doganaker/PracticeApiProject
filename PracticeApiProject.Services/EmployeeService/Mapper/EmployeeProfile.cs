using AutoMapper;
using PracticeApiProject.Domain.Entities;
using PracticeApiProject.Services.EmployeeService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApiProject.Services.EmployeeService.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeDto, Employee>();
        }
    }
}
