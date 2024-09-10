namespace Project.Data.Models
{
	public class Admin : BaseModel
	{
		public int Id { get; set; }
		public string Password { get; set; }
		public string? Address { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public List<Book>? BooksManaging { get; set; }

	}
}
