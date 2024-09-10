using Microsoft.EntityFrameworkCore;
using Project.Data.Context;
using Project.Repository.Repos;

namespace Project
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine("Welcome to the library :)");
			Console.WriteLine();

			Console.WriteLine("Enter Server name , or press ENTER for Default");
			string? SERVER = Console.ReadLine();
			string connectionString = "Server =LAPTOP-20J80S26\\SQLEXPRESS;Database = LibraryDB;trusted_Connection=true;trustservercertificate=true;";
			if (string.IsNullOrWhiteSpace(SERVER))
			{
				connectionString = "Server =.;Database = LibraryDB;trusted_Connection=true;trustservercertificate=true;";

			}
			else
			{
				connectionString = "Server =" + SERVER + ";Database = LibraryDB;trusted_Connection=true;trustservercertificate=true;";
			}
			//Console.WriteLine(connectionString);
			//LAPTOP-20J80S26\SQLEXPRESS
			Console.Clear();

			using var NewContext = new LibraryDBContext(connectionString);
			NewContext.Database.Migrate();
			Helper.SeedCategories(NewContext);

			Console.Write("Please enter 1 to Sign Up or any other char to Log In: ");
			string choice = Console.ReadLine()!;

			if (choice == "1")
			{
				Console.Write("Would you like to Sign Up as an 1- Admin or 2- Student? ");
				string sas = Console.ReadLine()!;
				if (sas == "1")
				{
					var adminrepo = new AdminRepo(NewContext);
					var current = adminrepo.AddNewAdmin();
					bool check = true;
					while (check)
					{
						Console.WriteLine("Would you like to:");
						Console.WriteLine("1- Update your info");
						Console.WriteLine("2- Add new book");
						Console.WriteLine("3- Update book details");
						Console.WriteLine("4- Delete book");
						Console.WriteLine("5- View books");
						Console.WriteLine("0- Exit");
						Console.Write("Please enter your choice: ");
						int c = int.Parse(Console.ReadLine()!);

						switch (c)
						{
							case 1:
								adminrepo.UpdateAdmin(current);
								break;
							case 2:
								adminrepo.AddBook(current);
								break;
							case 3:
								Console.Write("Enter the book's ISBN: ");
								int id = int.Parse(Console.ReadLine()!);
								adminrepo.UpdateBook(current, id);
								break;
							case 4:
								adminrepo.RemoveBooks();
								break;
							case 5:
								var bookrepo = new BooksRepo(NewContext);
								bookrepo.ViewBooks();
								break;
							case 0:
								Console.WriteLine("Thank you for using our library ;)");
								check = false;
								break;
							default:
								Console.WriteLine("That is not a valid option!");
								break;
						}
					}
				}
				else if (sas == "2")
				{
					var studentrepo = new StudentRepo(NewContext);
					var current = studentrepo.AddNewStudent();
					bool check = true;
					while (check)
					{
						Console.WriteLine("Would you like to:");
						Console.WriteLine("1- Update your info");
						Console.WriteLine("2- Update your interests");
						Console.WriteLine("3- Borrow a book");
						Console.WriteLine("4- View books");
						Console.WriteLine("0- Exit");
						Console.Write("Please enter your choice: ");
						int c = int.Parse(Console.ReadLine()!);

						switch (c)
						{
							case 1:
								studentrepo.UpdateStudent(current);
								break;
							case 2:
								studentrepo.AddPreferredCategories(current, NewContext);
								break;

							case 3:
								var bookr = new BooksRepo(NewContext);
								bookr.ShowAllBooks();
								Console.WriteLine("Enter the name of the book you want to borrow: ");
								string bookName = Console.ReadLine()!;
								var book = bookr.SearchBook(bookName); // Implement a method to search for a book
								if (book != null)
								{
									studentrepo.BorrowBook(current, book);
								}
								break;


							case 4:
								var bookrepo = new BooksRepo(NewContext);
								bookrepo.ViewBooks();
								break;
							case 0:
								Console.WriteLine("Thank you for using our library ;)");
								check = false;
								break;
							default:
								Console.WriteLine("That is not a valid option!");
								break;
						}
					}
				}
			}
			else
			{
				Console.Write("Would you like to Log In as an 1- Admin or 2- Student? ");
				string las = Console.ReadLine()!;
				if (las == "1")
				{
					var adminrepo = new AdminRepo(NewContext);
					var current = adminrepo.LogIn();
					bool check = true;
					while (check)
					{
						Console.WriteLine("Would you like to:");
						Console.WriteLine("1- Update your info");
						Console.WriteLine("2- Add new book");
						Console.WriteLine("3- Update book details");
						Console.WriteLine("4- Delete book");
						Console.WriteLine("5- View books");
						Console.WriteLine("0- Exit");
						Console.Write("Please enter your choice: ");
						int c = int.Parse(Console.ReadLine()!);

						switch (c)
						{
							case 1:
								adminrepo.UpdateAdmin(current);
								break;
							case 2:
								adminrepo.AddBook(current);
								break;
							case 3:
								Console.Write("Enter the book's ISBN: ");
								int id = int.Parse(Console.ReadLine()!);
								adminrepo.UpdateBook(current, id);
								break;
							case 4:
								adminrepo.RemoveBooks();
								break;
							case 5:
								var bookrepo = new BooksRepo(NewContext);
								bookrepo.ViewBooks();
								break;
							case 0:
								Console.WriteLine("Thank you for using our library ;)");
								check = false;
								break;
							default:
								Console.WriteLine("That is not a valid option!");
								break;
						}
					}
				}
				else if (las == "2")
				{
					var studentrepo = new StudentRepo(NewContext);
					var current = studentrepo.LogIn();
					bool check = true;
					while (check)
					{
						Console.WriteLine("Would you like to:");
						Console.WriteLine("1- Update your info");
						Console.WriteLine("2- Update your interests");
						Console.WriteLine("3- Borrow a book");
						Console.WriteLine("4- View books");
						Console.WriteLine("0- Exit");
						Console.Write("Please enter your choice: ");
						int c = int.Parse(Console.ReadLine()!);

						switch (c)
						{
							case 1:
								studentrepo.UpdateStudent(current);
								break;
							case 2:
								studentrepo.AddPreferredCategories(current, NewContext);
								break;
							case 3:
								var bookr = new BooksRepo(NewContext);
								bookr.ShowAllBooks();
								Console.WriteLine("Enter the name of the book you want to borrow: ");
								string bookName = Console.ReadLine()!;
								var book = bookr.SearchBook(bookName); // Implement a method to search for a book
								if (book != null)
								{
									studentrepo.BorrowBook(current, book);
								}
								break;
							case 4:
								var bookrepo = new BooksRepo(NewContext);
								bookrepo.ViewBooks();
								break;
							case 0:
								Console.WriteLine("Thank you for using our library ;)");
								check = false;
								break;
							default:
								Console.WriteLine("That is not a valid option!");
								break;
						}
					}
				}
			}
		}
	}
}
