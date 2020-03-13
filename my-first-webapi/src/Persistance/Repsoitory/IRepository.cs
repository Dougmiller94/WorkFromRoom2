using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Persistance.Repsoitory
{
    public interface IRepository<TEntity>
	{
		public Task<List<TEntity>> GetAllAsync();

		public Task<List<TEntity>> GetSingleAsync();

		public Task AddAnEntityAsync(TEntity entity);

		public void DeleteAsync(TEntity entity);

		public void Update(TEntity entity);

		public Task<int> Save();

	}
 
 
}
