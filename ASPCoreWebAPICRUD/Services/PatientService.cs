using Microsoft.EntityFrameworkCore;
using PatientManagement.DTOs;
using PatientManagement.Repositories;
using System.Threading.Tasks;

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
        public async Task<List<PatientWithAppointmentsDto>> GetPatientsWithAppointments()
        {
            return await _repo.GetPatientsWithAppointments();
        }
        public async Task<List<PatientWithNoAppointmentDto>> GetPatientWithNoAppointment()
        {
            return await _repo.GetPatientWithNoAppointment();
        }
    }
}
