using System.Linq.Expressions;
using WebApp.Data.IRepositories;
using WebApp.Domain.Commons;

namespace WebApp.Data.Repositories;
public class Repository<T> : IRepository<T> where T : Auditable
{
    public ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public ValueTask<T> InsertAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public ValueTask SaveAsync()
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, string[] includes = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        throw new NotImplementedException();
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }
}
