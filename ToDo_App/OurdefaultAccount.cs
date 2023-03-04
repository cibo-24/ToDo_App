using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App
{
    public static class OurdefaultAccount
    {
        private static Dictionary<int, Person> ourPerson = new Dictionary<int, Person>();
        public static Dictionary<int, Person> ourDefaultPerson()
        {
            ourPerson.Add(1, new Person("Bernard", "Aslanivo", 1));
            ourPerson.Add(2, new Person("Ricardo ", "Quaresma", 2));
            ourPerson.Add(3, new Person("Hakim", "Hakimov", 3));
            ourPerson.Add(4, new Person("Josef de", "Stalin", 4));
            ourPerson.Add(5, new Person("Lenide de", "Gradivo", 5));
            ourPerson.Add(6, new Person("Marskerano", "Da Silva", 6));
            ourPerson.Add(7, new Person("Guevara de", "Che Ernesto", 7));
            ourPerson.Add(8, new Person("Abuzerino", "Carlsberg", 8));
            ourPerson.Add(9, new Person("Andreas", "Beckinova", 9));
            ourPerson.Add(10, new Person("Kenançivo", "El Santiovaniva", 10));
           
            return ourPerson;

        }



    }
}
