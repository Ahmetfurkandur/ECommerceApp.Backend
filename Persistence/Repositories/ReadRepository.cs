using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

        private readonly ECommerceDbContext _context;

        public ReadRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
            => Table.Where(filter);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
            => await Table.FirstOrDefaultAsync(filter);

       
        public async Task<T> GetByIdAsync(int id)
        => await Table.FirstOrDefaultAsync(data => data.Id == id);
    }
}
