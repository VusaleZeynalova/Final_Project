using Core.CoreEntities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EmployeeDTOs
{
    public class EmployeeToUpdateDtoWithImage:IDto
    {
        public int EmployeeId { get; set; }
        public IFormFile ImagePath { get; set; }

    }
}
