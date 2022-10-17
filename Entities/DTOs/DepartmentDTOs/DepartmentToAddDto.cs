using Core.CoreEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.DepartmentDTOs
{
    public class DepartmentToAddDto : IDto
    {
        public string DepartmentName { get; set; }

    }
}
