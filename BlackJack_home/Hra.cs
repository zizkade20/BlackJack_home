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
                        Console.WriteLine("Cíl hry je se co nejblíže přiblížit součtem karet k 21. Pokud ho překročíš, automaticky prohráváš.");
                        break;
                    case "o":
                        Console.WriteLine("Black Jack (nebo též Blackjack) je jednou z nejoblíbenějších a nejrozšířenějších karetních her, s kterou se můžete v kasinu setkat. Black Jack je vyhledáván hráči, kteří se nespokojí pouze s tím, aby výsledek hry závisel čistě na náhodě. Naopak, mohou a chtějí svou šanci na výhru ovlivnit vhodně zvolenou strategií. Při nejlepším způsobu hry je dokonce možné nad krupiérem získat určitou výhodu, což je u jiných her jev prakticky nevídaný.");
                        break;
                    case "e":
                        Game = false;
                        break;
                }

            }
        }
    }
}
