using PatientManagement.DTOs;
using PatientManagement.Entities;

namespace PatientManagement.Services
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAppointments();
        Task<Appointment> CreateAppointment(Appointment appointment);
        Task<List<AppointmentsByDoctorDto>> GetAppointmentsByDoctor(int doctorId);
    }
}
