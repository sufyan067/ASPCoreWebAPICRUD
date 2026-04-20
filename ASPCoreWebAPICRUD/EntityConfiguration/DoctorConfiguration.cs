using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagement.Entities;

namespace PatientManagement.EntityConfiguration
{
    public class DoctorConfiguration:IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.DoctorId);

            builder.Property(d => d.FirstName).HasMaxLength(50);
            builder.Property(d => d.LastName).HasMaxLength(50);
            builder.Property(d => d.Specialization).HasMaxLength(100);
            builder.Property(d => d.ConsultationFee).HasPrecision(10, 2);
        }
    }
}
