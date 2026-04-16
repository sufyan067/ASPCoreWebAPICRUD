using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PatientManagement.Repositories;

namespace PatientManagement.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }
        public async Task<Patient> CreatePatient(Patient pat)
        {
            return await _repo.CreatePatient(pat);

        }

        public async Task<Patient?> DeletePatient(int id)
        {
            return await _repo.DeletePatient(id);

        }

        public async Task<Patient?> GetPatientById(int id)
        {
            return await _repo.GetPatientById(id);
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await _repo.GetPatients();
        }

        public async Task<Patient?> UpdatePatient(int id, Patient pat)
        {
            return await _repo.UpdatePatient(id, pat);

        }
    }
}
