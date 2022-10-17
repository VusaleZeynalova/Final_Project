using Core.CoreEntities.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GenericRepositories
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);

    }
}
