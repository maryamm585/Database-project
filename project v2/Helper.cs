using Project.Data.Context;
using Project.Data.Models;

namespace Project
{
	public static class Helper
	{
		static public void SeedCategories(LibraryDBContext db)
		{
			if (!db.Categories.Any())
			{
				List<string> strings = ["Fantasy",
					"Horror",
					"Science Fiction",
					"Crime", "Dystopian",
					"History", "Romance",
					"Adventure", "Paranormal",
					"Self_help"];

				foreach (string s in strings)
				{
					db.Categories.Add(new Category() { Name = s });
				}
				db.SaveChanges();
			}
		}
	}
}
