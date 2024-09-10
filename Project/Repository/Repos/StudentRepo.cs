using Microsoft.EntityFrameworkCore;
using Project.Data.Context;
using Project.Data.Models;

namespace Project.Repository.Repos
{
	public class StudentRepo : GenericRepository<Student>
	{
		private readonly LibraryDBContext context;
		protected DbSet<Faculty> faculties;
		protected DbSet<Category> categories;

		public StudentRepo(LibraryDBContext libraryDBContext) : base(libraryDBContext)
		{
			context = libraryDBContext;
			faculties = context.Faculties;
			categories = context.Categories;
		}

		public Student AddNewStudent()
		{
			var student = new Student();
			Console.Write("enter your university Id : ");
			int id = int.Parse(Console.ReadLine()!);
			while (_dbSet.Any(S => S.Id == id))
			{
				Console.WriteLine("this Id already exists , try another one");
				id = int.Parse(Console.ReadLine()!);
			}
			student.Id = id;

			Console.Write("Enter your First name : ");
			student.FirstName = Console.ReadLine()!;

			Console.Write("Enter your Last name : ");
			student.LastName = Console.ReadLine()!;

			student.Name = student.FirstName + " " + student.LastName;

			Console.Write("enter your email : ");
			var Email = Console.ReadLine()!;
			while (_dbSet.Any(S => S.Email == Email))
			{
				Console.WriteLine("this Email already exists , try another one");
				Email = Console.ReadLine()!;
			}
			student.Email = Email;

			Console.Write("Enter your Password : ");
			student.Password = Console.ReadLine()!;

			Console.Write("Enter your Age : ");
			student.Age = int.Parse(Console.ReadLine()!);

			Console.Write("Enter your College Year : ");
			student.CollegeYear = int.Parse(Console.ReadLine()!);

			Console.WriteLine();



			Console.Write("enter your faculty's name : ");
			string facultyName = Console.ReadLine()!.ToLower();
			var F = faculties.FirstOrDefault(F => F.Name == facultyName);
			if (F is null)
			{
				Faculty faculty = new Faculty
				{
					Name = facultyName
				};
				faculties.Add(faculty);
				context.SaveChanges();


			}
			student.FacultyId = faculties.FirstOrDefault(F => F.Name == facultyName)!.Id;


			var result = Add(student);
			if (result > 0)
				Console.WriteLine("student added successfully");
			else
				Console.WriteLine("no operations Done!");
			return student;



		}

		public Student LogIn()
		{
			var student = new Student();
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
					Console.WriteLine("Invalid username or password please try again");
				}
				else
				{
					student = _dbSet.FirstOrDefault(S => S.Email == email)!;
					flag = false;
					//user get out of the loop

				}
			}
			return student;
		}

		public void UpdateStudent(Student student)
		{
			Console.Write("Enter your First name : ");
			student.FirstName = Console.ReadLine()!;

			Console.Write("Enter your Last name : ");
			student.LastName = Console.ReadLine()!;

			student.Name = student.FirstName + " " + student.LastName;

			Console.Write("enter your email : ");
			var Email = Console.ReadLine()!;
			while (_dbSet.Any(S => S.Email == Email))
			{
				Console.WriteLine("this Email already exists , try another one");
				Email = Console.ReadLine()!;
			}
			student.Email = Email;

			Console.Write("Enter your new Password : ");
			student.Password = Console.ReadLine()!;

			Console.Write("Enter your Age : ");
			student.Age = int.Parse(Console.ReadLine()!);

			var result = Update(student);
			string s = result > 0 ? "your data is updated successfully" : "an error happened and no data updated";
			Console.WriteLine(s);
		}

		public void AddPreferredCategories(Student student, LibraryDBContext context)
		{
			var categories = context.Categories.ToList();
			Console.WriteLine($"Select preferred categories for student {student.Name}:");
			foreach (var category in categories)
			{
				Console.WriteLine($"   {category.Id}: {category.Name}");
			}

			Console.WriteLine("Enter the IDs of preferred categories separated by space:");
			var input = Console.ReadLine();
			var selectedCategoryIds = input.Split().Select(int.Parse).ToList();

			foreach (var categoryId in selectedCategoryIds)
			{
				var category = categories.FirstOrDefault(c => c.Id == categoryId);
				if (category != null)
				{
					student.PreferredCategories.Add(category);
					category.PreferredBy.Add(student);
				}
			}

			Console.WriteLine("Preferred categories added successfully.");
		}



		//public void AddInterested_In_categories(Student student, IEnumerable<Category> categories)
		//{
		//	Console.WriteLine("These are available categories:- ");
		//	foreach (var category in categories)
		//	{
		//		Console.WriteLine($"   {category.Id} : {category.Name}");
		//	}

		//	Console.WriteLine("Enter your preferred categories' IDs, separated by spaces: ");
		//	var IDs = Console.ReadLine()?.Split().Select(int.Parse) ?? [];

		//	foreach (var ID in IDs)
		//	{
		//		var category = categories.FirstOrDefault(c => c.Id == ID);
		//		if (category != null)
		//		{
		//			student.preferredcategories.Add(category);

		//			category.PreferredBy.Add(student);
		//		}
		//	}


		//	context.SaveChanges();
		//}
		public void BorrowBook(Student student, Book book)
		{
			if (book.IsBorrowed)
			{
				Console.WriteLine("the book is already borrowed.");
				return;
			}
			var borrowing = new Borrow();
			borrowing.BorrowDate = DateTime.Now;
			borrowing.DueDate = DateTime.Now.AddDays(30);
			book.IsBorrowed = true;
			borrowing.BookISBN = book.ISBN;
			borrowing.StudentId = student.Id;
			context.Books.Update(book);
			context.Borrows.Add(borrowing);
			context.SaveChanges();
			Console.WriteLine("** Book borrowed successfully ** ");

		}
	}
}