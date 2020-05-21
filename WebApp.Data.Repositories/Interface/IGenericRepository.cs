using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApp.Data.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {

        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T FindEntityBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T FindEntityAsNoTrackingBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> SQLQuery(string sql, params object[] parameters);
        bool ExecuteSqlCommand(string spName, Dictionary<string, object> parameters);
        T Add(T entity);
        void AddRange(List<T> entities);
        void Delete(T entity);
        void Edit(T entity);
        void RemoveRange(List<T> entities);
        void Save();

    }
}
