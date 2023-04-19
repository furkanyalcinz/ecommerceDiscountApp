using DataAccess.Abstact;
using DataAccess.Context;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RepositoryRead<T> : IRepositoryRead<T> where T : BaseEntity
    {
        private readonly DiscountContext _context;

        public RepositoryRead(DiscountContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }


        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
