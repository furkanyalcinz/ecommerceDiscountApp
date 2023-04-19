using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstact
{
    public interface IRepositoryWrite<T>:IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        Task<bool> Remove(int id);
        Task<int> SaveAsync();
    }
}
