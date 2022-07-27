using System.Linq.Expressions;

namespace ACG_Master.DataBase.Access
{
    public interface IServiceBase<T>
    {
        T Get(string id);
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
