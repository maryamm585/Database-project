using System.ComponentModel.DataAnnotations;

namespace Project.Data.Models
{
	public class Faculty : BaseModel
	{

		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		public List<Student> Students { get; set; }

	}
}
