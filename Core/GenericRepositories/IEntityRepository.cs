using Core.Entities.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.GenericRepositories
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        void  Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetALL(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
    }
}
