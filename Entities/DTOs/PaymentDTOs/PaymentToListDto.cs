using Core.CoreEntities.Abstract;
using Entities.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.PaymentDTOs
{
    public class PaymentToListDto : IDto
    {
        public int PaymentId { get; set; }
        public EmployeeToListPaymentDto Employee { get; set; }
        public int Salary { get; set; }
        public DateTime SalaryTime { get; set; }
    }
}
