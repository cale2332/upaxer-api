using WebApp.Common.Interfaces;
using WebApp.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace WebApp.Data.Repository.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _idbset;
        protected DbSet<T> _dbset;
        public GenericRepository(DbContext context)
        {
            _entities = context;

            _idbset = context.Set<T>();
        }


        public virtual IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var set = _idbset.AsQueryable();
            if (includes != null)
                set = includes.Aggregate(set, (current, include) => current.Include(include));

            return set.AsEnumerable();
        }

        public virtual IEnumerable<T> GetAllByFilters(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _idbset.Where(predicate).AsEnumerable();

            return query;
        }

        public virtual IQueryable<T> FindByBetween()
        {
            return _idbset;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var set = _idbset.Where(predicate);
            if (includes != null)
                set = includes.Aggregate(set, (current, include) => current.Include(include));
            return set.ToList();
        }

        public T FindEntityBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var set = _idbset.Where(predicate);
            if (includes != null)
                set = includes.Aggregate(set, (current, include) => current.Include(include));

            return set.FirstOrDefault();
        }

        public T FindEntityAsNoTrackingBy(Expression<Func<T, bool>> predicate)
        {
            var set = _idbset.AsNoTracking().Where(predicate);
            return set.FirstOrDefault();
        }

        public bool ExistEntityBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _idbset.Where(predicate).Any();
        }

        public IEnumerable<T> SQLQuery(string sql, params object[] parameters)
        {
            var list = _idbset.FromSql(sql, parameters).ToList();
            return list;
        }

        public bool ExecuteSqlCommand(string spName, Dictionary<string, object> parameters)
        {
            int result = 0;
            using (var connection = _entities.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = spName;
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var item in parameters)
                        {
                            //$"name:{item.Key}, age:{item.value}";
                            command.Parameters.Add(new SqlParameter($"{item.Key}", item.Value));
                        }
                    }

                    result = command.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        public virtual T Add(T entity)
        {
            var entry = _entities.Entry(entity);
            _idbset.Add(entity);
            SetPropertiesLog();
            return entity;

        }

        public virtual void AddRange(List<T> entities)
        {
            _dbset = _entities.Set<T>();
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbset.AddRange(entities);
            SetPropertiesLog();
        }

        public virtual void Delete(T entity)
        {
            _idbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            var entry = _entities.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            entry.State = EntityState.Modified;

            SetPropertiesLog();

        }

        public virtual void RemoveRange(List<T> entities)
        {
            _dbset = _entities.Set<T>();
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            _dbset.RemoveRange(entities);
            SetPropertiesLog();
        }

        private void SetPropertiesLog()
        {
            string userName = string.Empty;

            var user = ClaimsPrincipal.Current;
            if (user != null)
            {
                var identity = user.Identity;
                if (identity != null)
                {
                    userName = identity.Name;
                }
            }


            var modifiedEntries = _entities.ChangeTracker.Entries().Where(x => x.Entity is IAuditableEntity
                   && (x.State == (EntityState)EntityState.Added || x.State == (EntityState)EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.Active = true;
                        entity.CreatedBy = userName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        _entities.Entry(entity).Property("CreatedBy").IsModified = false;
                        _entities.Entry(entity).Property("CreatedDate").IsModified = false;

                        entity.UpdatedBy = userName;
                        entity.UpdatedDate = now;
                    }

                }

            }

        }

        public virtual void Save()
        {
            using (var transaction = _entities.Database.BeginTransaction())
            {
                try
                {
                    _entities.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    if (ex.InnerException == null) throw ex;
                    throw ex.InnerException.GetBaseException();
                }
            }

        }

    }
}
