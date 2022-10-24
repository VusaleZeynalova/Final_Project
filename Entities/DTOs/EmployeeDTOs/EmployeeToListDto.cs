using Core.CoreEntities.Abstract;
using Entities.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EmployeeDTOs
{
    public class EmployeeToListDto:IDto
    {
        public int EmployeeId { get; set; }
        public DepartmentToListDto Department { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime? LastDay { get; set; }
        public string ImagePath { get; set; }
    }
}
