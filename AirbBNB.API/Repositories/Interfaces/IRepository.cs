using System;
using System.Linq.Expressions;

namespace AirbBNB.API.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public T FindOne(Expression<Func<T, bool>> expression);
        public void Add(T entity);
        public void Commit();
    }
}
