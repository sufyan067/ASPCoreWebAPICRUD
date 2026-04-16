using Microsoft.EntityFrameworkCore;
using PatientManagement.Models.Data;

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
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> UpdatePatient(int id, Patient pat)
        {
            if (id != pat.PatientId)
                return null;

            _context.Entry(pat).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return pat;
        }
    }
}
