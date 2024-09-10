namespace Project.Data.Models
{
	public class Student : BaseModel
	{
		public int Id { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int? Age { get; set; }
		public int CollegeYear { get; set; }

		//**********************************************************************
		public int? FacultyId { get; set; }
		public Faculty BelongsTo { get; set; }

		//**********************************************************************

		public List<Category> PreferredCategories { get; set; } = [];

		//**********************************************************************

		public List<Borrow> Borrowings { get; set; } = [];





	}
}
