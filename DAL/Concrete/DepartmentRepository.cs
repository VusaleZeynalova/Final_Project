using Core.GenericRepositories;
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
    public class DepartmentRepository:EntityRepositoryBase<Department,DataContext>,IDepartmentRepository
    {
    }
}
