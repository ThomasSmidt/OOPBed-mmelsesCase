namespace OOPBedømmelsesCase
{
    public class Patient : Person
    {
        public Patient(string firstName, string lastName, int phoneNr, Doctor doctor) : base(firstName, lastName, phoneNr)
        {
            CheckIfAssignmentIsCompatible(doctor);
        }

        public override void CheckIfAssignmentIsCompatible(Doctor doctor)
        {
            var assign = new Assignment(this, doctor);

            try
            {
                if (!IsCompatibleDoctor(assign))
                {
                    throw new Exception("\nPatienter kan ikke tildeles både en kirurg og en onkolog som læge.");
                }

                if (DoctorHas3OrMorePatients(assign))
                {
                    throw new Exception("\nEn læge må højst være tildelt 3 patienter.");
                }

                if (IsAlreadyAssignedToPatient(assign))
                {
                    throw new Exception("\nPatienten er allerede tildelt denne læge");
                }
                else
                {
                    Assignment.Assignments.Add(assign);
                    Console.WriteLine($"\n{assign.Patient.FullName} er nu tildelt {assign.Doctor.FullName} ({assign.Doctor.Title})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}