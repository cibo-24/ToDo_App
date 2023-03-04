using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_App
{
    public abstract class CartManager
    {
        private string title;
        private string contents;
        private Person appointedPerson;
        private string cartName;// Sadece bu değişken farklıdır ve ismi değiştirilemez bu yüzden setter'ı yoktur
        private Size size;


        public CartManager(string cartName, string title, string contents, Person appointedPerson, Size size)
        {
            this.title = title;
            this.contents = contents;
            this.appointedPerson = appointedPerson;
            this.cartName = cartName;
            this.size = size;

        }



        public string Title { get => title; set => title = value; }
        public string Contents { get => contents; set => contents = value; }
        public Person AppointedPerson { get => appointedPerson; set => appointedPerson = value; }
        public string CartName { get => cartName; }
        public Size Size { get => size; }

    }

    public enum Size
    {
        XS = 2,
        S = 3,
        M = 5,
        L = 7,
        XL = 9
    }



}

