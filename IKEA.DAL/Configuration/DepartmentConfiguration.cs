using IKEA.DAL.Models.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(p => p.Id).UseIdentityColumn(10, 10);
            builder.Property(p => p.Name).HasColumnType("varchar(20)");
            builder.Property(p => p.Code).HasColumnType("varchar(20)");
        }
    }
}
