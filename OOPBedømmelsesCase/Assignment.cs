using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBedømmelsesCase
{
    internal class Assignment
    {
        public static List<Assignment> Assignments = new();
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public Assignment(Patient patient, Doctor doctor)
        {
            Patient = patient;
            Doctor = doctor;
            if(doctor.Title == DoctorTypes.Onkolog && Assignments.Any(x => x.Patient == patient && x.Doctor.Title == DoctorTypes.Kirurg) 
                || doctor.Title == DoctorTypes.Kirurg && Assignments.Any(x => x.Patient == patient && x.Doctor.Title == DoctorTypes.Onkolog))
            {
                Console.WriteLine("Patienter kan ikke tildeles både en kirurg og en onkolog som læge.");
                throw new Exception("Patienter kan ikke tildeles både en kirurg og en onkolog som læge.");
            }
            if (Assignments.Where(assignment => assignment.Doctor.Title == doctor.Title).Count() >= 3)
            {
                Console.WriteLine("En læge må højst være tildelt 3 patienter.");
                throw new Exception("En læge må højst være tildelt 3 patienter.");
            }
            Assignments.Add(this);
        }
    }
}
