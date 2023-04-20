using DataAccess.Abstact;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

namespace DataAccess.Concrete
{
    public class RepositoryWrite<T>:IRepositoryWrite<T> where T : BaseEntity
    {
        readonly private DiscountContext _context;

        public RepositoryWrite(DiscountContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            var res = entityEntry.State == EntityState.Added;
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> Remove(int id)
        {
            T entity = await Table.FirstOrDefaultAsync(e => e.Id == id);
            return Remove(entity);
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public bool Update(T entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            var res = updatedEntity.State == EntityState.Modified;
            _context.SaveChanges();

            return res;
        }
        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
    }
}
