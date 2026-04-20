using PatientManagement.DTOs;
using PatientManagement.Entities;
using PatientManagement.Repositories;

namespace PatientManagement.Services
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IAppointmentRepository _repo;
        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            return await _repo.CreateAppointment(appointment);
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            return await _repo.GetAppointments();
        }
        public async Task<List<AppointmentsByDoctorDto>> GetAppointmentsByDoctor(int doctorId)
        {
            return await _repo.GetAppointmentsByDoctor(doctorId);
        }
    }
}
