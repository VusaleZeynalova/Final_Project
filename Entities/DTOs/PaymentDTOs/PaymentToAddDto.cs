using Core.CoreEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.PaymentDTOs
{
    public class PaymentToAddDto:IDto
    {
        public int EmployeeId { get; set; }
        public int Salary { get; set; }
        public DateTime SalaryTime { get; set; }
    }
}
