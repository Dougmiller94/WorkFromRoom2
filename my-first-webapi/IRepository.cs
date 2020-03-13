using System;

public class IRepository<TEntity>
{
	public Task<List<TEntity>> GetAllAsync();

	public Task<List<TEntity>> GetSingleAsync();

	public Task AddAsync (TEntity entity);

	public void DeleteAsync(TEntity entity);

	public void UpdateAsync(TEntity entity);

	public Task<int> Save();


}
	
