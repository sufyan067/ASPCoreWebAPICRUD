using PatientManagement.DTOs;
using PatientManagement.Entities;

namespace PatientManagement.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointments();
        Task<Appointment> CreateAppointment(Appointment appointment);
        Task<List<AppointmentsByDoctorDto>> GetAppointmentsByDoctor(int doctorId);
    }
}
