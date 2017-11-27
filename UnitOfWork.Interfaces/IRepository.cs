using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UstSoft.EnglishTraining.UnitOfWork.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> expression);

        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entitys);
        Task AddRangeAsync(IEnumerable<T> entitys);
        //void BulkInsert(IEnumerable<T> entities);
        //void BulkInsertOrUpdate(IEnumerable<T> entities);
        //void BulkDelete(IEnumerable<T> entities);
        void Delete(T entity);

        void AddEntity<TEntity>(TEntity entity) where TEntity : class;

        T GetById(int id);
        T GetSingle(Expression<Func<T, bool>> expression);
    }
}
