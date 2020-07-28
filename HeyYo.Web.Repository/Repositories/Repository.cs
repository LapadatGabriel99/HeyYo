using HeyYo.Web.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyYo.Web.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task Add(T model)
        {
            await _context.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<T> models)
        {
            await _context.AddRangeAsync(models);

            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById<Id>(Id id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task Remove(T model)
        {
            _context.Remove(model);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<T> models)
        {
            _context.RemoveRange(models);

            await _context.SaveChangesAsync();
        }

        public async Task Update(T model)
        {
            _context.Update(model);

            await _context.SaveChangesAsync();
        }       

        public async Task UpdateRange(IEnumerable<T> models)
        {
            _context.UpdateRange(models);

            await _context.SaveChangesAsync();
        }
    }
}
