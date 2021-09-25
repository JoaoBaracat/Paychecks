using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paychecks.Domain.Entities;

namespace Paychecks.Infra.Data.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)");

            builder.Property(x => x.LastName).IsRequired()
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)");

            builder.Property(x => x.CPF).IsRequired()
                .HasMaxLength(11)
                .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.Sector).IsRequired()
                .HasMaxLength(20)
                .HasColumnType("VARCHAR(20)");

            builder.Property(x => x.GrossSalary).IsRequired()
                .HasColumnType("money");

            builder.Property(x => x.AdmissionDate).IsRequired();

            builder.ToTable("Employees");
        }
    }
}