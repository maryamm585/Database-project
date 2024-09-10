using Microsoft.EntityFrameworkCore;
using Project.Data.Context;
using Project.Data.Models;

namespace Project.Repository.Repos
{
	public class AdminRepo : GenericRepository<Admin>
	{
		private readonly LibraryDBContext context;
		protected DbSet<Book> Books;

		public AdminRepo(LibraryDBContext libraryDBContext) : base(libraryDBContext)
		{
			context = libraryDBContext;
			Books = context.Books;
		}

		public Admin AddNewAdmin()
		{
			Admin admin = new Admin();
			Console.Write("Enter your name : ");
			admin.Name = Console.ReadLine()!;

			Console.Write("enter your email : ");
			var Email = Console.ReadLine()!;
			while (_dbSet.Any(S => S.Email == Email))
			{
				Console.WriteLine("this Email already exists , try another one");
				Email = Console.ReadLine()!;
			}
			admin.Email = Email;

			Console.Write("Enter your Password : ");
			admin.Password = Console.ReadLine()!;

			Console.WriteLine("enter your address (optional)");
			admin.Address = Console.ReadLine();
			Add(admin);

			return admin;
		}

		public Admin LogIn()
		{
			Admin admin = new();
			bool flag = true;
			while (flag)
			{
				Console.Write("Enter your email : ");
				var email = Console.ReadLine()!;
				Console.Write("Enter your Password : ");
				var Password = Console.ReadLine()!;
				if (!_dbSet.Any(S => S.Email == email && S.Password == Password))
				{
					//invalid user
					Console.WriteLine("Invalid email or password please try again");
				}
				else
				{
					//valid user get out of the loop
					flag = false;
					admin = _dbSet.FirstOrDefault(S => S.Email == email)!;

				}
			}
			return admin!;

		}

		public void UpdateAdmin(Admin admin)
		{
			Console.Write("Enter your Name : ");
			admin.Name = Console.ReadLine()!;

			Console.Write("enter your email : ");
			var Email = Console.ReadLine()!;
			while (_dbSet.Any(A => A.Email == Email))
			{
				Console.WriteLine("this Email already exists , try another one");
				Email = Console.ReadLine()!;
			}
			admin.Email = Email;

			Console.Write("Enter your new Password : ");
			admin.Password = Console.ReadLine()!;

			Console.Write("Enter your Address : ");
			admin.Address = Console.ReadLine()!;

			var result = Update(admin);
			string a = result > 0 ? "your data is updated successfully" : "an error happened and no data updated";
			Console.WriteLine(a);
		}

		public void AddBook(Admin admin)
		{
			Book book = new Book();
			Console.WriteLine("Enter book's name : ");
			book.Name = Console.ReadLine()!;
			Console.WriteLine("Enter author's name : ");
			book.Author = Console.ReadLine()!;
			Console.WriteLine("add some description (optional) : ");
			book.Description = Console.ReadLine();

			book.IsBorrowed = false;
			book.AdminID = admin.Id;


			Console.WriteLine("select the category ID from below :-");
			var cat = context.Categories.ToList();
			foreach (var Category in cat)
			{
				Console.WriteLine(Category.Id + " " + Category.Name);
			}

			int bookCatId = int.Parse(Console.ReadLine()!);
			book.CategoryID = bookCatId;
			context.Books.Add(book);
			context.SaveChanges();

		}




		public void RemoveBooks()
		{
			if (context.Books != null)
			{
				foreach (var book in context.Books)
				{
					Console.WriteLine(book.Name + " ,Written by " + book.Author + " ,Category : " + book.Category);
				}

				Console.WriteLine("\ndelete by : \n	1 : Name of Book\n	3 : Category of Book\n	3 : Name of Author");
				int choice = int.Parse(Console.ReadLine()!);
				if (choice == 1)
				{
					Console.WriteLine("enter the name of the book : ");
					string bName = Console.ReadLine()!;
					var book = Books.Where(B => B.Name.ToLower() == bName.ToLower()).FirstOrDefault();
					if (book != null)
					{
						Books.Remove(book);
						Console.WriteLine("book deleted successfully");
					}
					else
					{
						Console.WriteLine($"there are no books with the name {bName}");
					}


				}
				else if (choice == 2)
				{
					Console.WriteLine("choose the ID of the category you want to delete its books");
					var cat = context.Categories.ToList();
					foreach (var Category in cat)
					{
						Console.WriteLine(Category.Id + " " + Category.Name);
					}
					int c = int.Parse(Console.ReadLine()!);
					var toBeDeleted = Books.Where(B => B.CategoryID == c).ToArray();
					Books.RemoveRange(toBeDeleted);
					Console.WriteLine("Books removed!");
				}
				else
				{
					Console.WriteLine("Enter the name of the author : ");
					string Aname = Console.ReadLine()!;
					var book = Books.Where(B => B.Author.Equals(Aname, StringComparison.CurrentCultureIgnoreCase));
					if (book != null)
					{
						Books.RemoveRange(book);
						Console.WriteLine("books deleted successfully");
					}
					else
					{
						Console.WriteLine($"there are no books with Author name {Aname}");
					}


				}
				context.SaveChanges();
			}



		}


		public void UpdateBook(Admin CurrentAdmin, int id)
		{
			var book = Books.FirstOrDefault(B => B.ISBN == id);
			if (book != null)
			{
				Console.WriteLine("Enter book's name : ");
				book.Name = Console.ReadLine()!;
				Console.WriteLine("Enter author's name : ");
				book.Author = Console.ReadLine()!;
				Console.WriteLine("add some description (optional) : ");
				book.Description = Console.ReadLine();

				book.IsBorrowed = false;
				book.AdminID = CurrentAdmin.Id;


				Console.WriteLine("select the category ID from below :-");
				var cat = context.Categories.ToList();
				foreach (var Category in cat)
				{
					Console.WriteLine(Category.Id + " " + Category.Name);
				}

				int bookCatId = int.Parse(Console.ReadLine()!);
				book.CategoryID = bookCatId;
				context.Books.Update(book);

				context.SaveChanges();
				Console.WriteLine("**Book updated! **");

			}
		}



		//********************************************************************************************



		public void RemoveStudent(int id)
		{
			var student = context.Students.FirstOrDefault(S => S.Id == id);
			if (student != null)
			{
				context.Students.Remove(student);
				Console.WriteLine("student account deleted");
				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("No student with this ID");
			}
		}

		public void MoveStudentsToNextYear(int id)
		{
			var student = context.Students.First(S => S.Id == id);
			if (student != null)
			{
				student.CollegeYear++;
				context.Students.Update(student);
				Console.WriteLine("student's data updated");
				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("No Student with this ID");
			}
		}
	}
}
