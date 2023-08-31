using Newtonsoft.Json;

namespace OOPBedømmelsesCase
{
    public class Doctor : Person
    {
        public static List<Doctor>? Doctors = new();
        public DoctorTypes Title { get; set; }
        public int? ID { get; set; }
        private static int Counter = 1;
        public Doctor(string firstName, string lastName, int phoneNr, DoctorTypes title) : base(firstName, lastName, phoneNr)
        {
            Title = title;
            ID = Counter++;
            Doctors.Add(this);
        }
    }
}
