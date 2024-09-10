using Microsoft.EntityFrameworkCore;
using Project.Data.Context;
using Project.Data.Models;

namespace Project.Repository.Repos
{
	public class BooksRepo : GenericRepository<Book>
	{
		private LibraryDBContext _dbContext;
		public BooksRepo(LibraryDBContext context) : base(context)
		{
			_dbContext = context;
		}

		public void ShowAllBooks()
		{
			var books = _dbSet.Select(B => new
			{
				B.Name,
				B.Author,
			}).ToList();
			foreach (var book in books)
			{
				Console.WriteLine(book.Name + " written by:" + book.Author);
			}




		}

		public void ViewBooks()
		{

			var books = new List<Book>();
			Console.WriteLine("1 : View all books\n2 : View Books of a certain Category\n3 : View Books by Author's Name");
			int c = int.Parse(Console.ReadLine()!);

			if (c == 1)
			{
				books = _dbSet.Include(B => B.ManagedBy).Include(B => B.Category).ToList();
			}
			else if (c == 2)
			{
				var cat = _dbContext.Categories.ToArray();
				foreach (var i in cat)
				{
					Console.WriteLine(i.Id + " : " + i.Name);

				}
				Console.WriteLine("enter category Id  : ");
				int catId = int.Parse(Console.ReadLine()!);
				books = _dbSet.Where(B => B.CategoryID == catId).Include(B => B.ManagedBy).Include(B => B.Category).ToList();
			}
			else
			{
				Console.WriteLine("enter author's name: ");
				string name = Console.ReadLine()!;
				books = _dbSet.Where(B => B.Author == name).Include(B => B.ManagedBy).Include(B => B.Category).ToList();
			}

			var Viewed = books.Select(B => new
			{
				B.ISBN,
				name = B.Name,
				author = B.Author,
				category = B.Category.Name,
				B.Description,
				CreatedBy = B.ManagedBy.Name,
			});

			foreach (var i in Viewed)
			{
				Console.WriteLine(i.ToString());
			}


		}

		public Book? SearchBook(string bookName)
		{
			// Search by book name
			var book = _dbSet.FirstOrDefault(b => b.Name == bookName);
			// If book is not found, inform the user
			if (book == null)
				Console.WriteLine($"Book with name '{bookName}' not found.");

			return book;
		}

		public void ViewBookDetails(Book B)
		{
			Console.WriteLine("Book ISBN : ");
			Console.WriteLine(B.ISBN);
			Console.WriteLine();

			Console.WriteLine("Name of book : ");
			Console.WriteLine(B.Name);
			Console.WriteLine();

			Console.WriteLine("Written By : ");
			Console.WriteLine(B.Author);
			Console.WriteLine();

			Console.WriteLine("Categorized as : ");
			Console.WriteLine(B.Category.Name);
			Console.WriteLine();

			Console.WriteLine("Description : ");
			Console.WriteLine(B.Description);
			Console.WriteLine();

			Console.WriteLine("Managed by : ");
			Console.WriteLine(B.ManagedBy.Name);
			Console.WriteLine();




		}
	}
}
