namespace PatientManagement.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }   //  Primary Key

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Specialization { get; set; }

        public decimal ConsultationFee { get; set; }

        public bool IsAvailable { get; set; }

        //  Navigation Property (1 Doctor → Many Appointments)
        public List<Appointment> Appointments { get; set; } = new();
    }
}
