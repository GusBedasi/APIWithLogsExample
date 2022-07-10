using AirbBNB.API.Database;
using AirbBNB.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AirbBNB.API.Repositories
{
    public class BaseRepository<T> : DbContext, IRepository<T> where T : class
    {
        private readonly AirBnbContext _context;

        public BaseRepository(AirBnbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(T entity)
        {
            Set().Add(entity);
        }

        public T FindOne(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> set = _context.Set<T>();

            return set.FirstOrDefault(expression);
        }

        public void Commit(T entity)
        {
            _context.SaveChanges();
        }

        protected DbSet<T> Set()
        {
            return _context.Set<T>();
        }
    }
}
