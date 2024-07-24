using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ReadyGo.Service.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        bool Insert(T entity);
        void InsertRange(List<T> entities);
        bool Update(T entity);
        void UpdateRange(List<T> entities);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        T FindBy(Expression<Func<T, bool>> predicate);
    }
}
