using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Hrac
    {
        public string Jmeno { get; set; }
        //public List<Karta> Ruka { get; set; }
        public int Skore = 0;
        public int Penize = 200;
        public int sazka;

        internal Hrac() { }
        internal Hrac(string _jmeno)
        {
            this.Jmeno = _jmeno;
        }

        internal void SetName()
        {
            Console.WriteLine("Zadejte přezdívku:");
            Console.Write("->");
            string username = Console.ReadLine();
            Console.WriteLine("\nVítej " + username);
            Hrac Hrac1 = new Hrac();
            Hrac1.Jmeno = username;

            
        }
        /*internal void DisplayName()
        {
            Console.WriteLine(username);
        }
        */
    }

}
