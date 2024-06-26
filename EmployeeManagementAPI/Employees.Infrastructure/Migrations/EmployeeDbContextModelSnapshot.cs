﻿// <auto-generated />
using System;
using Employees.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employees.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employees.Domain.Employees.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("EmployeeId");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Employees.Domain.Employees.Employee", b =>
                {
                    b.OwnsOne("Employees.Domain.Employees.Employee.Address#Employees.Domain.Employees.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PostalCode");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsMany("Employees.Domain.Employees.Employee.Skills#Employees.Domain.Skills.EmployeeSkill", "Skills", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Id")
                                .HasColumnType("nvarchar(450)")
                                .HasColumnName("SkillId");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.Property<string>("SeniorityRating")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("SeniorityRating");

                            b1.Property<int>("YearsOfExperience")
                                .HasColumnType("int");

                            b1.HasKey("EmployeeId", "Id");

                            b1.ToTable("EmployeeSkills", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
