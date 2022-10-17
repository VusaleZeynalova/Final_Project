using DAL.GenericRepositories;
using DAL.Abstract;
using DAL.DataBaseContext;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    public class EmployeeRepository : EntityRepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;

        }

        public async Task<List<Employee>> GetWithInclude()
        {
            return await _dataContext.Employees.Include(d => d.Department).ToListAsync();
        }
    }
}
