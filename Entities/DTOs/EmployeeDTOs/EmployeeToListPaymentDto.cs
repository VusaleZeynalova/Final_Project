using Core.CoreEntities.Abstract;
using Entities.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EmployeeDTOs
{
    public class EmployeeToListPaymentDto : IDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
    }
}
