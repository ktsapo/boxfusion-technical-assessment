using Employees.Domain.Employees;
using Employees.Domain.Employees.ValueObjects;
using Employees.Domain.Skills.Enums;
using Employees.Domain.Skills.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infrastructure.Persistance.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.OwnsOne(e => e.Address, a =>
            {
                a.Property(a => a.City)
                    .HasColumnName("City")
                    .IsRequired();
                a.Property(a => a.PostalCode)
                    .HasColumnName("PostalCode")
                    .IsRequired();
                a.Property(a => a.Country)
                    .HasColumnName("Country")
                    .IsRequired();
            });



            builder.Property(e => e.Id)
                .HasColumnName("EmployeeId")
                .HasConversion(
                    id => id.Value,
                    value => EmployeeId.Create(value)
                )
                .ValueGeneratedNever();

            builder.OwnsMany(s => s.Skills, sb =>
            {
                sb.ToTable("EmployeeSkills");
                sb.Property(s => s.Id)
                    .HasColumnName("SkillId")
                    .HasConversion(
                        id => id.Value,
                        value => SkillId.Create(value)
                    )
                    .ValueGeneratedNever();
                sb.Property(s => s.Name)
                    .HasColumnName("Name")
                    .IsRequired();

                sb.Property(s => s.SeniorityRating)
                    .HasColumnName("SeniorityRating")
                    .IsRequired()
                    .HasConversion(
                        rating => rating.ToString(),
                        value => (SeniorityRating)Enum.Parse(typeof(SeniorityRating), value)
                    );
            });
        }
    }
}
