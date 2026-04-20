using Microsoft.EntityFrameworkCore;
using PatientManagement.Data;
using PatientManagement.DTOs;
using PatientManagement.Entities;

namespace PatientManagement.Repositories
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private readonly PatientDbContext _context;

        public AppointmentRepository(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            return await _context.Appointments
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<AppointmentsByDoctorDto>> GetAppointmentsByDoctor(int doctorId)
        {
            return await _context.Appointments.AsNoTracking()
                .Where(a => a.DoctorId == doctorId)
                .Select(a => new AppointmentsByDoctorDto
                {
                    AppointmentId = a.AppointmentId,
                    DoctorName = a.Doctor.FirstName,
                    PatientName = a.Patient.FirstName,
                    AppointmentDate = a.AppointmentDate,
                    Status = a.Status,
                    VisitType = a.VisitType,

                })
                .ToListAsync();
        }
    }
}
