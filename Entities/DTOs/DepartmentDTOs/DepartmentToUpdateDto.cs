using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.DepartmentDTOs
{
    public class DepartmentToUpdateDto : IDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
