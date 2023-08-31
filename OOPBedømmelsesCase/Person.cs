namespace OOPBedømmelsesCase
{
    public abstract class Person : IPerson
    {
        public Person(string firstName, string lastName, int phoneNr)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}"; 
            PhoneNr = phoneNr;
        }

        public virtual void CheckIfAssignmentIsCompatible(Doctor doctor) { }
        public static bool IsCompatibleDoctor(Assignment assign)
        {
            if (assign.Doctor.Title == DoctorTypes.Onkolog && Assignment.Assignments.Any(x => x.Patient.FullName == assign.Patient.FullName && x.Doctor.Title == DoctorTypes.Kirurg)
                || assign.Doctor.Title == DoctorTypes.Kirurg && Assignment.Assignments.Any(x => x.Patient.FullName == assign.Patient.FullName && x.Doctor.Title == DoctorTypes.Onkolog))
            {
                return false;
            }

            return true;
        }

        public static bool IsAlreadyAssignedToPatient(Assignment assign)
        {
            if (Assignment.Assignments.Any(x => x.Doctor.Title == assign.Doctor.Title && x.Patient.FullName == assign.Patient.FullName))
            {
                return true;
            }
            return false;
        }

        public static bool DoctorHas3OrMorePatients(Assignment assign)
        {
            if (Assignment.Assignments.Where(assignment => assignment.Doctor.Title == assign.Doctor.Title).Count() >= 2)
            {
                return true;
            }
            return false;
        }
    }
}