using Employees.Domain.Aggregates.EmployeeAggregate;
using Employees.Domain.Aggregates.EmployeeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infrastructure.Persistance.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("EmployeeId")
                .HasConversion(
                    id => id.Value,
                    value => EmployeeId.Create(value)
                )
                .ValueGeneratedNever();
        }
    }
}
