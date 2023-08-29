using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBedømmelsesCase
{
    public class Person : IPerson
    {
        public Person(string firstName, string lastName, int phoneNr)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}"; 
            PhoneNr = phoneNr;
        }
    }
}
