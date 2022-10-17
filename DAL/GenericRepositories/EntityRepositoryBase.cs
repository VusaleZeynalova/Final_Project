using Core.CoreEntities.Abstract;
using DAL.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace DAL.GenericRepositories
{
    public class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DataContext _datacontext;
        public EntityRepositoryBase(DataContext dataContext)
        {
            _datacontext = dataContext;

        }
        public async Task Add(TEntity entity)
        {
            await _datacontext.AddAsync(entity);

        }
        public void Delete(TEntity entity)
        {
            _datacontext.Remove(entity);
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {

            return _datacontext.Set<TEntity>().FirstOrDefault(filter);

        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
               ? _datacontext.Set<TEntity>().ToList()
               : _datacontext.Set<TEntity>().Where(filter).ToList();

        }



        public void Update(TEntity entity)
        {
            var updatedEntity = _datacontext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
        }

    }
}
