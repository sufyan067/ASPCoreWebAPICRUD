using System.Numerics;

namespace PatientManagement.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string? Status { get; set; }      // e.g. Scheduled, Completed
        public string? VisitType { get; set; }   // e.g. OPD, Emergency

        //  Foreign Keys
        public int PatientId { get; set; }
        public int? DoctorId { get; set; }

        //  Navigation Property
        public Patient? Patient { get; set; }               // public Patient Patient { get; set; } = null!;
        public Doctor? Doctor { get; set; }
    }
}
