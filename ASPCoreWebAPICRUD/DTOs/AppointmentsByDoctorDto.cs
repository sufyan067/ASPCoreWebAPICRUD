namespace PatientManagement.DTOs
{
    public class AppointmentsByDoctorDto
    {
        public int AppointmentId { get; set; }
        public string? DoctorName { get; set; }
        public string? PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Status { get; set; }
        public string? VisitType { get; set; }

    }
}
