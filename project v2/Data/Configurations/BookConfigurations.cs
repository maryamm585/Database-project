using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Models;

namespace Project.Data.Configurations
{
	public class BookConfigurations : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(B => B.ISBN);
			builder.HasOne(B => B.ManagedBy).WithMany(A => A.BooksManaging).HasForeignKey(B => B.AdminID);
			builder.HasOne(B => B.Category).
				WithMany(C => C.Books).
				HasForeignKey(B => B.CategoryID);

		}
	}
}
