using Core.CoreEntities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public  Department Department { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime? LastDay { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }

    }
}
