using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Core.GenericRepositories
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public void Add(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                var addedEntity = ctx.Entry(entity);
                addedEntity.State = EntityState.Added;
                ctx.SaveChanges();

            }

        }
        public void Delete(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                var deletedEntity = ctx.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                ctx.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext ctx = new TContext())
            {
                return ctx.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetALL(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext ctx = new TContext())
            {
                return filter == null
                   ? ctx.Set<TEntity>().ToList()
                   : ctx.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                var uptatedEntity = ctx.Entry(entity);
                uptatedEntity.State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
