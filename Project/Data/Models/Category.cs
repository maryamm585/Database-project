namespace Project.Data.Models
{
	public class Category : BaseModel

	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<Book>? Books { get; set; } = [];

		public List<Student> PreferredBy { get; set; } = [];

	}
}
