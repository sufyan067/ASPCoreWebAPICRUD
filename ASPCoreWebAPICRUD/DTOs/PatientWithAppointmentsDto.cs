namespace PatientManagement.DTOs
{
    public class PatientWithAppointmentsDto
    {
        public int PatientId { get; set; }
        public string? FirstName { get; set; }
        public int AppointmentCount { get; set; }
    }
}
