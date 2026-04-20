using Microsoft.EntityFrameworkCore;
using PatientManagement.Data;
using PatientManagement.DTOs;

namespace PatientManagement.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _context;

        public PatientRepository(PatientDbContext context)
        {
            _context = context;
        }
        public async Task<Patient> CreatePatient(Patient pat)
        {
            await _context.Patients.AddAsync(pat);
            await _context.SaveChangesAsync();
            return pat;
        }

        public async Task<Patient?> DeletePatient(int id)
        {
            var pat = await _context.Patients.FindAsync(id);
            if (pat == null)
                return null;

            _context.Patients.Remove(pat);
            await _context.SaveChangesAsync();

            return pat;
        }

        public async Task<Patient?> GetPatientById(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await _context.Patients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Patient?> UpdatePatient(int id, Patient pat)
        {
            if (id != pat.PatientId)
                return null;

            _context.Entry(pat).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return pat;
        }
        public async Task<List<PatientWithAppointmentsDto>> GetPatientsWithAppointments()
        {
            return await _context.Patients
                .AsNoTracking()
                .Select(p => new PatientWithAppointmentsDto
                {
                    PatientId = p.PatientId,
                    FirstName = p.FirstName,
                    AppointmentCount = p.Appointments.Count
                })
                .ToListAsync();
        }
        public async Task<List<PatientWithNoAppointmentDto>> GetPatientWithNoAppointment()
        {
            return await _context.Patients.AsNoTracking()
                .Where(p=>!p.Appointments.Any())
                .Select(p=>new PatientWithNoAppointmentDto
                {
                    PatientId = p.PatientId,
                    FirstName = p.FirstName,
                    AppointmentCount= 0
                })
                .ToListAsync();

        }

    }
}
