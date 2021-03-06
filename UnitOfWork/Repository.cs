﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UstSoft.EnglishTraining.UnitOfWork.Interfaces;

namespace UstSoft.EnglishTraining.UnitOfWork
{
    public class Repository
    {
        protected EnglishTrainingDbContext Context;

        public Repository(IUnitOfWork unitOfWork)
        {
            Context = unitOfWork as EnglishTrainingDbContext;

            if (Context == null)
                throw new InvalidOperationException("UnitOfWork of the type EnglishTrainingDbContext should be used while a entity framework data access are used.");
        }
    }

    public class Repository<T> : Repository, IRepository<T> where T : class, IIdentifiable
    {
        public Repository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return GetAll().FirstOrDefault(expression);
        }

        protected virtual IQueryable<T> GetMainAll()
        {
            return Context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return GetMainAll();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        //public void BulkInsert(IEnumerable<T> entities)
        //{
        //    Context.BulkInsert(entities);
        //}

        //public void BulkInsertOrUpdate(IEnumerable<T> entities)
        //{
        //    Context.BulkInsertOrUpdate(entities);
        //}

        //public void BulkDelete(IEnumerable<T> entities)
        //{
        //    Context.BulkDelete(entities);
        //}

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entitys)
        {
            Context.Set<T>().AddRange(entitys);
        }

        public async Task AddRangeAsync(IEnumerable<T> entitys)
        {
            await Context.Set<T>().AddRangeAsync(entitys);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, bool>> expression)
        {
            return GetAll().FirstOrDefault(expression);
        }

        public void AddEntity<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Entry(entity).State = EntityState.Added;
        }
    }
}
