using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBedømmelsesCase
{
    public class Assignment
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

            if (!Assignments.Any(x => x.Doctor.Title == doctor.Title && x.Patient.FullName == patient.FullName))
            {
                Assignments.Add(this);
            } else
            {
                Console.WriteLine("\nPatienten er allerede tildelt denne læge");
            }
        }

        private bool IsCompatibleDoctor(Assignment assign)
        {
            if(assign.Doctor.Title == DoctorTypes.Onkolog && Assignments.Any(x => x.Patient == assign.Patient && x.Doctor.Title == DoctorTypes.Kirurg) 
                || assign.Doctor.Title == DoctorTypes.Kirurg && Assignments.Any(x => x.Patient == assign.Patient && x.Doctor.Title == DoctorTypes.Onkolog))
            {
                return false;
            }

            return true;
        }
    }
}
