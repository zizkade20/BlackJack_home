using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        // Funkce obsahující menu hry 
        public void Loop()
        {

            
            //vytvoření přezdívky
            Console.WriteLine("Zadejte přezdívku:");
            Console.Write("->");
            string username = Console.ReadLine();

            var Hrac1 = new Hrac(username);
            
            // While dokud hráč neopustí hru tlačítkem exit
            while (Game)
            {
                Console.WriteLine("\n(P)LAY\n(Z)EBRICEK\n(J)AK HRÁT?\n(O) HRE\n(E)XIT");
                Console.Write("->");
                string menuVolba = Console.ReadLine().ToLower();
                
                switch (menuVolba)
                {
                    case "p":
                        Balicek Balicek1 = new Balicek();

                        int value;
                        Console.WriteLine("Zůstatek: " + Hrac1.Penize + "$\n");
                        Console.WriteLine("Zadej sazku:");
                        int sazka = 0;
                        // Ošetření vstupu pouze na int
                        if (Int32.TryParse(Console.ReadLine(), out Hrac1.Score))
                            if (Hrac1.Score <= Hrac1.Penize && Hrac1.Score != 0)
                            {
                                Hrac1.Win = false;

                               

                                Hrac1.Penize -= Hrac1.Score;

                                Balicek1.CreateDeck();

                                
                                if (Hrac1.Win == true)
                                {
                                    Hrac1.Penize += (Hrac1.Score * 2);
                                } 
                                else if (Hrac1.Blackjack == true)
                                {
                                    Hrac1.Penize += (Hrac1.Score * 4);
                                }
                                

                            }
                            else
                            {
                                Console.WriteLine("\nNemáš dost peněz!");
                            }
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
    // Funkce na vytvoření csv souboru a zapsání hodnot do souboru
    internal bool WriteToLeaderboard(string jmeno, int bank)
    {
        string FileName = "../../../leaderboard.csv";
        string personDetail = jmeno + "," + pocet + Environment.NewLine;

        if (!File.Exists(FileName)){
            string clientHeader = Environment.NewLine;

            File.WriteAllText(FileName, clientHeader);
        }

        File.AppendAllText(FileName, personDetail);

        return true;
    }

    // Funkce na zobrazení dat z csv souboru
    internal void DisplayLeaderboard()
    {
        string[] leaderboard = System.IO.File.ReadAllLines(@"../../../leaderboard.csv");
        foreach(string line in leaderboard)
        {
            Console.WriteLine(line);
        }
    }
    }
    
}

