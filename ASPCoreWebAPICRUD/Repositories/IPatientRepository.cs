using PatientManagement.DTOs;

namespace PatientManagement.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetPatients();
        Task<Patient?> GetPatientById(int id);
        Task<Patient> CreatePatient(Patient pat);
        Task<Patient?> UpdatePatient(int id, Patient pat);
        Task<Patient?> DeletePatient(int id);
        Task<List<PatientWithAppointmentsDto>> GetPatientsWithAppointments();
        Task<List<PatientWithNoAppointmentDto>> GetPatientWithNoAppointment();

    }
}
