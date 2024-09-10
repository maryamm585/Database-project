using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Models;

namespace Project.Data.Configurations
{
	public class StudentConfigurations : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasKey(S => S.Id);
			builder.Property(S => S.Id).ValueGeneratedNever().IsRequired();
			builder.HasOne(S => S.BelongsTo).WithMany(F => F.Students).HasForeignKey(S => S.FacultyId);
			builder.HasMany(S => S.PreferredCategories).WithMany(C => C.PreferredBy);
			// builder.HasMany(S => S.Borrowings).WithOne(B => B.Student).HasForeignKey(B => B.StudentId);

		}
	}
}
