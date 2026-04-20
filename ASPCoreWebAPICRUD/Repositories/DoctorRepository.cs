using Microsoft.EntityFrameworkCore;
using PatientManagement.Data;
using PatientManagement.Entities;

namespace PatientManagement.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly PatientDbContext _context;
        public DoctorRepository(PatientDbContext context)
        {
            _context = context;

        }
        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async  Task<List<Doctor>> GetDoctors()
        {
            return await _context.Doctors
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
