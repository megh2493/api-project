namespace APIProject.Models
{
    public class Patients
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string MedicalNotes { get; set; }

        public string NextVisitDate { get; set; }

        public string Zip { get; set; }

        public string Cell { get; set; }

        public int PracticeId { get; set; }
    }
}
