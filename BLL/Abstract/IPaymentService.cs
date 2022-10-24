using DAL.Abstract;
using Entities.DTOs.EmployeeDTOs;
using Entities.DTOs.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IPaymentService
    {
        Task Add(PaymentToAddDto paymentToAddDto);
        Task<List<PaymentToListDto>> Get(int empId); 
    }
}
