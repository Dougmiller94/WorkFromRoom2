using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using src.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Persistance.Repsoitory
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly ILogger<Repository<TEntity>> _logger;

        public Repository(ILogger<Repository<TEntity>> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
            _dbSet = context.Set<TEntity>();

        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAnEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }


    }
}
 
