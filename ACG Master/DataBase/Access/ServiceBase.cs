using ACG_Master.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACG_Master.DataBase.Access
{

    /// <summary>
    /// a base service for main actions of any data service
    /// </summary>
    /// <typeparam name="T">Entity of extended service</typeparam>
    public class ServiceBase<T> : IServiceBase<T> where T : class, IEntity, new()
    {
        protected ACGContext context;
        public ServiceBase(ACGContext _context)
        {
            context = _context;
        }
        public void Add(T entity)
        {

            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();

        }

        public void Delete(string id)
        {
            var removedEntity = context.Entry(id);
            var deletedEntity = context.Entry(removedEntity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual T Get(string id)
        {
            return context.Find<T>(id); ;
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return context.Set<T>().SingleOrDefault(filter);
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();

        }

        public void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
