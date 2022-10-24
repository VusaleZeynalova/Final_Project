using DAL.GenericRepositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IPaymentRepository:IEntityRepository<Payment>
    {
        Task<List<Payment>> GetWithInclude();
        Task<List<Payment>> GetEmployee(int empId);

    }
}
