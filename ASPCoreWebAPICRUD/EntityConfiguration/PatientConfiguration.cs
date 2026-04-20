using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagement.Entities;
using PatientManagement.Models;
namespace PatientManagement.EntityConfiguration
{
    public class PatientConfiguration:IEntityTypeConfiguration<Patient> 
    {
        public void Configure(EntityTypeBuilder<Patient> builder) {
            builder.HasKey(p => p.PatientId);

            builder.Property(p => p.FirstName)
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .HasMaxLength(50);

            builder.Property(p => p.Email)
                .HasMaxLength(100);

            builder.Property(p => p.City)
                .HasMaxLength(50);

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(15);
        }
    }
}
