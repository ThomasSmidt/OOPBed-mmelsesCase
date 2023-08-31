namespace OOPBedømmelsesCase
{
    public class UI
    {
        public static void Menu()
        {
            Console.Write("Indtast patientens fornavn: ");
            string firstName = Console.ReadLine();
            Console.Write("Indtast patientens efternavn: ");
            string lastName = Console.ReadLine();
            int phoneNr = ValidatePhoneNumber();
            
            AssignPatientToDoctor(firstName, lastName, phoneNr);
            Menu();
        }

        private static int ValidatePhoneNumber()
        {
            while (true)
            {
                Console.Write("Indtast patientens telefonnummer: ");
                var phoneNrInput = Console.ReadLine();
                if (phoneNrInput.Length == 8 && Int32.TryParse(phoneNrInput, out int phoneNr))
                {
                    return phoneNr;
                }
                else
                {
                    Console.WriteLine("Fejl. Indtast et gyldig telefonnummer");
                }
            }
        }

        private static void AssignPatientToDoctor(string firstName, string lastName, int phoneNr)
        {
            while (true)
            {
                DisplayDoctors();

                if (!TryGetUserInput(out int userInput))
                {
                    Console.WriteLine("Fejl. Indtastning er ikke et gyldigt tal. Prøv igen.\n");
                    continue;
                }

                Doctor matchingDoctor = GetMatchingDoctor(userInput);

                Patient newPatient = new(firstName, lastName, phoneNr, matchingDoctor);

                if (matchingDoctor == null)
                {
                    Console.WriteLine("\nFejl. Ingen matchende Doctor fundet. Prøv igen.\n");
                    continue;
                }


                if (!AskForAnotherDoctor())
                {
                    break;
                }
            }
        }

        private static void DisplayDoctors()
        {
            foreach (Doctor doc in Doctor.Doctors)
            {
                Console.WriteLine($"{doc.ID}. {doc.Title}");
            }
            Console.Write("\nTryk på tallet svarende til den læge du gerne vil tildeles: ");
        }

        private static bool TryGetUserInput(out int userInput)
        {
            ConsoleKeyInfo ck = Console.ReadKey();
            return int.TryParse(ck.KeyChar.ToString(), out userInput);
        }

        private static Doctor GetMatchingDoctor(int userInput)
        {
            return Doctor.Doctors.FirstOrDefault(doc => doc.ID == userInput);
        }

        private static bool AskForAnotherDoctor()
        {
            Console.Write("\nVil du gerne tildele patienten endnu en læge? [J/N] ");
            ConsoleKeyInfo key = Console.ReadKey();
            char input = char.ToLower(key.KeyChar);
            Console.WriteLine();

            if (input == 'j')
            {
                return true;
            }
            else if (input == 'n')
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nFejl. Du skal taste enten 'J' for ja, eller 'N' for nej.");
                return AskForAnotherDoctor();
            }
        }
    }
}
