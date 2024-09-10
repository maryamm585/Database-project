using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Models;

namespace Project.Data.Configurations
{
	public class AdminConfigurations : IEntityTypeConfiguration<Admin>
	{
		public void Configure(EntityTypeBuilder<Admin> builder)
		{
			builder.HasKey(A => A.Id);
			builder.Property(A => A.Id).UseIdentityColumn(1, 1);
			builder.Property(A => A.Name).IsRequired();
			builder.Property(A => A.Password).IsRequired();
			builder.Property(A => A.Address).IsRequired(false);









		}
	}
}
