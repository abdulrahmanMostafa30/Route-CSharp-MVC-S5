using AutoMapper;
using AutoMapper.Configuration.Conventions;
using IKEA.BLL.DTO.EmployeeDto_s;
using IKEA.DAL.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IKEA.BLL.Common.MappingProfiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeDetailsDto>().ReverseMap();
            CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
        }
    }
}
