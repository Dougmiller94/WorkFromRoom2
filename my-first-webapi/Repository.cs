using System;

namespace src.Persistence.Repository
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //public Task<List<TEntity>> GetAllAsync();

        //public Task<List<TEntity>> GetSingleAsync();

        //public Task AddAnEntityAsync(TEntity entity);

        //public void DeleteAsync(int id);

        //public Task UpdateAsync(TEntity entity);

        //public Task<int> Save();

        private readonly MyContext _context;
        private readonly Dbset<TEntity> _dbSet;
        private readonly ILogger<Repository<TEntity>> _logger;

        public Repository(ILogger<Repository<TEntity>> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
            _dbset = context.Set<TEntity>();

        }


    }
}