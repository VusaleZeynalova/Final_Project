using DAL.GenericRepositories;
using DAL.Abstract;
using DAL.DataBaseContext;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class DepartmentRepository : EntityRepositoryBase<Department>, IDepartmentRepository
    {
        private readonly DataContext _dataContext;
        public DepartmentRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;

        }
    }
}
