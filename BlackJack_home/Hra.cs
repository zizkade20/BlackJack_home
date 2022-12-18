using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Hra
    {
        internal bool Game;

        internal Hra()
        {
            Game = true;
        }

        public void Loop()
        {
            Hrac hrac1 = new Hrac();
            hrac1.SetName();



            while (Game)
            {
                Console.WriteLine("\n(P)LAY\n(Z)EBRICEK\n(J)AK HRÁT?\n(O) HRE\n(E)XIT");
                Console.Write("->");
                string menuVolba = Console.ReadLine().ToLower();

                switch (menuVolba)
                {
                    case "p":
                        Balicek Balicek1 = new Balicek();
                        //Balicek1.VratKartu();
                        Balicek1.CreateDeck();
                        
                        break;
                    case "z":
                        break;
                    case "j":
                        Console.WriteLine("Toto jsou pravidla");
                        break;
                    case "o":
                        break;
                    case "e":
                        Game = false;
                        break;
                }



            }
        }
    }
}
