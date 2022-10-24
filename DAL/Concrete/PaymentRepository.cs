using DAL.Abstract;
using DAL.DataBaseContext;
using DAL.GenericRepositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class PaymentRepository : EntityRepositoryBase<Payment>, IPaymentRepository
    {
        private readonly DataContext _dataContext;
        public PaymentRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Payment>> GetEmployee(int empId)
        {
            return await _dataContext.Payments.Include(k=>k.Employee).Where(e=>e.EmployeeId==empId).ToListAsync();

        }

        public async Task<List<Payment>> GetWithInclude()
        {
            return await _dataContext.Payments.Include(e => e.Employee).ToListAsync();
        }
    }
}
