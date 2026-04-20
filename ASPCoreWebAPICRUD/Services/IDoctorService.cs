using PatientManagement.Entities;

namespace PatientManagement.Services
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetDoctors();
        Task<Doctor> CreateDoctor(Doctor doctor);
    }
}
