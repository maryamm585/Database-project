using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Models
{
	public class Book : BaseModel
	{
		[Key]
		public int ISBN { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string? Description { get; set; }

	     [NotMapped]
		public bool IsBorrowed { get; set; } = false;



		// admin nav property (one to many)
		public int AdminID { get; set; }
		public Admin ManagedBy { get; set; }

		// category nav property
		public Category Category { get; set; }
		public int? CategoryID { get; set; }



	}
}
