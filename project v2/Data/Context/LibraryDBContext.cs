using Microsoft.EntityFrameworkCore;
using Project.Data.Configurations;
using Project.Data.Models;

namespace Project.Data.Context
{
	public class LibraryDBContext : DbContext
	{

		//private readonly string? ConnectionString;
		private readonly string? ConnectionString = "Server =LAPTOP-20J80S26\\SQLEXPRESS;Database = LibraryDataBase;trusted_Connection=true;trustservercertificate=true;";
		public LibraryDBContext(string? connectionString)
		{
			ConnectionString = connectionString;
		}

		public LibraryDBContext()
		{

		}



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			optionsBuilder.UseSqlServer(ConnectionString);
			optionsBuilder.EnableSensitiveDataLogging();
		}


		public DbSet<Student> Students { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<Borrow> Borrows { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			modelBuilder.ApplyConfiguration(new StudentConfigurations());
			modelBuilder.ApplyConfiguration(new AdminConfigurations());
			modelBuilder.ApplyConfiguration(new BookConfigurations());
			modelBuilder.ApplyConfiguration(new BorrowConfigurations());


		}
	}
}
