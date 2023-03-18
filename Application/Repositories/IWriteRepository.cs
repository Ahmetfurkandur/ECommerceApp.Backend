using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Remove(T entity);
        Task<bool> RemoveAsync(int id);
        bool RemoveRange(List<T> entities);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
