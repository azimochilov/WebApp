﻿using System.Linq.Expressions;
using WebApp.Domain.Commons;

namespace WebApp.Data.IRepositories;
public interface IRepository<T> where T : Auditable
{
    ValueTask<T> InsertAsync(T entity);
    T Update(T entity);
    IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, string[] includes = null);
    ValueTask<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    
    ValueTask SaveAsync();
}
