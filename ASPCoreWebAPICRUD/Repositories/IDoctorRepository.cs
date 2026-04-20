using PatientManagement.Entities;

namespace PatientManagement.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetDoctors();
        Task<Doctor> CreateDoctor(Doctor doctor);
    }
}
