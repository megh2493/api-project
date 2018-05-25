namespace APIProject.Models
{
    public class Appointments
    {
        public int PatientId { get; set; }

        public int PracticeId { get; set; }

        public string AppointmentDate { get; set; }

        public string AppointmentTime { get; set; }

        public string Description { get; set; }
    }
}
