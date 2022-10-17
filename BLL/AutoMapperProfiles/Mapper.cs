using AutoMapper;
using Core.CoreEntities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.DepartmentDTOs;
using Entities.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AutoMapperProfiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<UserToAddDto,User>();
            CreateMap<UserRegisterDto,User>();
            CreateMap<UserRegisterDto, UserToAddDto>();

            CreateMap<DepartmentToAddDto, Department>();
            CreateMap<DepartmentToUpdateDto, Department>();
            CreateMap<Department, DepartmentToListDto>();

            CreateMap<EmployeeToAddDto, Employee>();
            CreateMap<EmployeeToUpdateDto, Employee>();
            CreateMap<Employee, EmployeeToListDto>();
            CreateMap<EmployeeToUpdateDtoWithImage, Employee>();
        }
    }
}
