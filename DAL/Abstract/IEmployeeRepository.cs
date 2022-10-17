using DAL.GenericRepositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        Task<List<Employee>> GetWithInclude();
    }
}
