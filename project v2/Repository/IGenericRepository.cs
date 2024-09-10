using Project.Data.Models;

namespace Project.Repository
{
	public interface IGenericRepository<T> where T : BaseModel
	{
		// Retrieve entity by its unique identifier
		T GetById(int id);
		// Retrieve all entities
		IEnumerable<T> GetAll();
		int Add(T entity);
		int Delete(T entity);
		int Update(T entity);

	}
}
