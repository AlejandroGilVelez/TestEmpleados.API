﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestEmpleados.DataModel
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll();

        Task<IList<T>> GetAll(params Expression<Func<T, object>>[] includes);

        Task<T> Find(Expression<Func<T, bool>> predicate);

        Task<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<IList<T>> FindAll(Expression<Func<T, bool>> predicate);

        Task<T> Add(T entity);

        Task<T> Delete(T entity);

        Task<T> Edit(T entity);
    }
}
