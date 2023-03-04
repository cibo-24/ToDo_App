using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App
{
    public class Todokart:CartManager
    {

        public static List<Todokart> Carts = new List<Todokart>();

        public Todokart(string title, string contents, Person appointedPerson) :
            base("To-Do LİSTESİ", title, contents, appointedPerson, Size.L)
        {
            Carts.Add(this);
        }

        public static void listToCarts()
        {
            for (int i = 0; i < Carts.Count; i++)
            {
                Console.WriteLine("Kart adı: " + Carts[i].Title);
                Console.WriteLine("Kart içeriği: " + Carts[i].Contents);
                Console.WriteLine("Atanan Kişi:  " + Carts[i].AppointedPerson.Name + " " + Carts[i].AppointedPerson.SurName);
                Console.WriteLine("Kart Büyüklüğü: " + Carts[i].Size);
                Console.WriteLine("---------------------------------------------------");
            }
        }


    }
}
