using IKEA.DAL.Models.Employee;
using IKEA.DAL.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Name).HasColumnType("varchar(50)");
            builder.Property(p => p.Address).HasColumnType("varchar(150)");
            builder.Property(p => p.Salary).HasColumnType("decimal(10,3)");
            builder.Property(p => p.Gender).HasConversion(egender => egender.ToString(), gender => (Gender)Enum.Parse(typeof(Gender), gender));
            builder.Property(p => p.EmployeeType).HasConversion(emptype => emptype.ToString(), temptype => (EmployeeType)Enum.Parse(typeof(EmployeeType), temptype));

        }
    }
}
