namespace PatientManagement.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetPatients();
        Task<Patient?> GetPatientById(int id);
        Task<Patient> CreatePatient(Patient pat);
        Task<Patient?> UpdatePatient(int id, Patient pat);
        Task<Patient?> DeletePatient(int id);

    }
}
