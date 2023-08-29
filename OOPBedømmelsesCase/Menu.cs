using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBedømmelsesCase
{
    public class Menu
    {
        public static void MenuSetup()
        {
            int phoneNr;
            Console.Write("Indtast patientens fornavn: ");
            string firstName = Console.ReadLine();
            Console.Write("Indtast patientens efternavn: ");
            string lastName = Console.ReadLine();
            
            while(true)
            {
                Console.Write("Indtast patientens telefonnummer: ");
                var phoneNrInput = Console.ReadLine();
                if (phoneNrInput.Length == 8 && Int32.TryParse(phoneNrInput, out phoneNr))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Fejl. Indtast et gyldig telefonnummer");
                }
            }

            Patient newPatient = new(firstName, lastName, phoneNr);

            while (true)
            {
                foreach (Doctor doc in Doctor.Doctors)
                {
                    Console.WriteLine($"{doc.ID}. {doc.Title}");
                }
                Console.Write("\nTryk på tallet svarende til den læge du gerne vil tildeles:");
                ConsoleKeyInfo ck = Console.ReadKey();

                if (int.TryParse(ck.KeyChar.ToString(), out int userInput))
                {
                    Doctor matchingDoctor = Doctor.Doctors.FirstOrDefault(doc => doc.ID == userInput);

                    if (matchingDoctor != null)
                    {
                        Assignment assign = new Assignment(newPatient, matchingDoctor);
                        Console.WriteLine($"\n{newPatient.FullName} er nu tildelt {matchingDoctor.FullName} ({matchingDoctor.Title})");

                        Console.Write("\nVil du gerne tildele patienten endnu en læge? [J/N] ");
                        ConsoleKeyInfo addAnotherDoctor = Console.ReadKey();
                        Console.WriteLine();
                        if (addAnotherDoctor.KeyChar == 'j' && addAnotherDoctor != null)
                        {
                            //Restart loop
                        } else if (addAnotherDoctor.KeyChar == 'n' && addAnotherDoctor != null)
                        {
                            break;
                        } else
                        {
                            Console.WriteLine("\nFejl. Du skal taste enten 'J' for ja, eller 'N' for nej.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fejl. Ingen matchende Doctor fundet. Prøv igen.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Fejl. Indtastning er ikke et gyldigt tal. Prøv igen.\n");
                }
            }
            MenuSetup();
        }
    }
}
