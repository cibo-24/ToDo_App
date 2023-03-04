using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App
{
    public class Person

    {
        private string name;
        private string surName;
        private int iD;


        public Person(string name, string surName, int iD)
        {
            this.name = name;
            this.surName = surName;
            this.iD = iD;
        }

        public string Name { get => name; set => name = value; }
        public string SurName { get => surName; set => surName = value; }

        public int ID { get => iD; }




    }
}
