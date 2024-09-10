using Microsoft.EntityFrameworkCore;
using Project.Data.Context;
using Project.Data.Models;

namespace Project.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
	{
		private readonly LibraryDBContext _context;
		protected DbSet<T> _dbSet;

		public GenericRepository(LibraryDBContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();

		}
		public int Add(T entity)
		{
			_dbSet.Add(entity);
			return _context.SaveChanges();
		}

		public int Delete(T entity)
		{
			_dbSet.Remove(entity);
			return _context.SaveChanges();
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public T GetById(int id)
		{
			return _dbSet.Find(id)!;
		}

		public int Update(T entity)
		{
			_dbSet.Update(entity);
			return _context.SaveChanges();
		}
	}
}
