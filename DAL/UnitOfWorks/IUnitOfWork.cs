using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IPaymentRepository PaymentRepository { get; set; }

        Task Commit();
    }
}
