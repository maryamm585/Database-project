

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Models;
namespace Project.Data.Configurations
{
    public class BorrowConfigurations : IEntityTypeConfiguration<Borrow>
    {
        public void Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.HasKey(B => B.Id);
            builder.Property(B => B.Id).UseIdentityColumn(1, 1);
            builder.HasOne(B => B.BorrowedBook).WithOne().HasForeignKey<Borrow>(B => B.BookISBN);
            builder.HasOne(B => B.BorrowedBy).WithMany(S => S.Borrowings).HasForeignKey(B => B.StudentId);

        }
    }
}