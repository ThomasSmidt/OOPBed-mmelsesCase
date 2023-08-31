namespace OOPBedømmelsesCase
{
    public class Assignment
    {
        public static List<Assignment>? Assignments = new();
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public Assignment(Patient patient, Doctor doctor)
        {
            Patient = patient;
            Doctor = doctor;
        }
    }
}