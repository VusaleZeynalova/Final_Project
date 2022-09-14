using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.DepartmentDTOs;
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
        }
    }
}
