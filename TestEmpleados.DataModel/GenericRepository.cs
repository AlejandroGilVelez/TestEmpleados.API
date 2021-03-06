﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestEmpleados.DataModel
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }
        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Edit(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> consulta = context.Set<T>().Where(predicate);

            foreach (var item in includes)
            {
                consulta = consulta.Include(item);
            }

            return await consulta.FirstOrDefaultAsync();

        }

        public async Task<IList<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            IList<T> consulta = await context.Set<T>().Where(predicate).ToListAsync();

            return consulta;
        }

        public async Task<IList<T>> GetAll()
        {
            var consulta = await context.Set<T>().ToListAsync();

            return consulta;
        }

        public async Task<IList<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {         

            IQueryable<T> consulta =  context.Set<T>();

            foreach (var item in includes)
            {
                consulta = consulta.Include(item);
            }

            return await consulta.ToListAsync();
        }
    }
}
