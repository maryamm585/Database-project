using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Models
{
    public class Borrow : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        //////
        public Student BorrowedBy { get; set; }
        public Book BorrowedBook { get; set; }

        public int StudentId { get; set; }
        public int BookISBN { get; set; }

    }
}