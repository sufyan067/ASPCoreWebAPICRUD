using PatientManagement.Entities;
using PatientManagement.Repositories;

namespace PatientManagement.Services
{

    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;

        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;

        }
        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            return await _repo.CreateDoctor(doctor);
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _repo.GetDoctors();
        }
    }
}
