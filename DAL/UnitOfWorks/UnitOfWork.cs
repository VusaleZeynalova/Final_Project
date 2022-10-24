using DAL.Abstract;
using DAL.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IPaymentRepository PaymentRepository { get; set; }
        public UnitOfWork
            (DataContext dataContext,
            IDepartmentRepository departmentRepository,
            IUserRepository userRepository,
            IEmployeeRepository employeeRepository,
            IPaymentRepository paymentRepository
            )
        {
            _dataContext = dataContext;
            DepartmentRepository = departmentRepository;
            EmployeeRepository = employeeRepository;
            UserRepository = userRepository;
            PaymentRepository = paymentRepository;
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
