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
            Balicek Balicek1 = new Balicek();


            List<string> PlayerCards = new List<string>();
            List<string> DealerCards = new List<string>();

            Random ran = new Random();
            //vytvoření přezdívky
            Console.WriteLine("Zadejte přezdívku:");
            Console.Write("->");
            string username = Console.ReadLine();

            var Hrac1 = new Hrac(username);
            Balicek.CreateDeck();

            // While dokud hráč neopustí hru tlačítkem exit
            while (Game)
            {
                Console.WriteLine("\n(P)LAY\n(Z)EBRICEK\n(J)AK HRÁT?\n(O) HRE\n(E)XIT");
                Console.Write("->");
                string menuVolba = Console.ReadLine().ToLower();
                
                switch (menuVolba)
                {
                    case "p":

                        int value;
                        Console.WriteLine("Zůstatek: " + Hrac1.Penize + "$\n");
                        Console.WriteLine("Zadej sazku:");
                        int sazka = 0;
                        // Ošetření vstupu pouze na int
                        if (Int32.TryParse(Console.ReadLine(), out sazka))
                            if (sazka <= Hrac1.Penize && sazka != 0)
                            {
                                // hráč i dealer si líznou 2 karty
                                var HracLiznuteKarty = Balicek.Lizni(Balicek.ShowDeck(), 2);
                                var DealerLiznuteKarty = Balicek.Lizni(Balicek.ShowDeck(), 2);

                                bool hit = true;
                                while (hit)
                                {

                                    Balicek.KartyRuka(HracLiznuteKarty);

                                    Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(HracLiznuteKarty));
                                    // Pokud má hráč součet 21 z prvních dvou karet, má blackjack
                                    if (Balicek.CountCards(HracLiznuteKarty) == 21 && HracLiznuteKarty.Count == 2)
                                    {
                                        hit = false;

                                        Console.WriteLine("Gratuluji máš Blackjack!");

                                        Hrac1.Penize += sazka * 4;


                                        break;
                                    // Pokud nemá hned blackjack, volí mezi líznout, stát a double
                                    } else
                                    {
                                        Console.WriteLine("\n(H)it / (S)tand / (D)ouble");
                                        string volba = Console.ReadLine().ToLower();

                                        switch (volba)
                                        {
                                            // když hráč vybere hit, přičtě se mu jedna karta
                                            case "h":

                                                List<string> adding = Balicek.Lizni(Balicek.ShowDeck(), 1);

                                                HracLiznuteKarty.AddRange(adding);

                                                // pokud má přes 21, automaticky prohrál
                                                if (Balicek.CountCards(HracLiznuteKarty) > 21)
                                                {

                                                    hit = false;

                                                    Balicek.KartyRuka(HracLiznuteKarty);
                                                    Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(HracLiznuteKarty));

                                                    Console.WriteLine("Máš přes 21, prohál jsi! :(");
                                                    Hrac1.Penize -= sazka;
                                                // pokud má součet 21 ale více než 2 karty, vyhrál ale nemá blackjack
                                                } else if (Balicek.CountCards(HracLiznuteKarty) == 21 && HracLiznuteKarty.Count > 2)
                                                {
                                                    hit = false;

                                                    Console.WriteLine("Gratuluji máš 21");

                                                    Hrac1.Penize += sazka;


                                                }
                                                break;
                                            // když hráč vybere double, dostane už jenom jednu kartu a zdvojnásobí se jeho sázka.
                                            case "d":

                                                hit = false;

                                                int dabl = sazka * 2;

                                                List<string> addingg = Balicek.Lizni(Balicek.ShowDeck(), 1);

                                                HracLiznuteKarty.AddRange(addingg);
                                                // Dealer líže, dokud nemá hodnotu v ruce větší než 16
                                                while (Balicek.CountCards(DealerLiznuteKarty) <= 16)
                                                {

                                                    List<string> addin = Balicek.Lizni(Balicek.ShowDeck(), 1);

                                                    DealerLiznuteKarty.AddRange(addin);

                                                }

                                                Balicek.KartyRuka(HracLiznuteKarty);
                                                Balicek.KartyKrup(DealerLiznuteKarty);

                                                Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(HracLiznuteKarty));
                                                Console.WriteLine("Součet dealerových karet je: " + Balicek.CountCards(DealerLiznuteKarty));

                                                if (Balicek.CountCards(HracLiznuteKarty) == 21 && HracLiznuteKarty.Count == 2)
                                                {
                                                    hit = false;

                                                    Console.WriteLine("Dealer má Blackjack, prohrál jsi! :(");

                                                    Hrac1.Penize -= dabl;


                                                }
                                                    // pokud má dealer více než hráč, a hráč nemá v ruce více než 21, dealer vyhrál
                                                if (Balicek.CountCards(HracLiznuteKarty) > Balicek.CountCards(DealerLiznuteKarty) && Balicek.CountCards(HracLiznuteKarty) <= 21)
                                                {
                                                hit = false;


                                                Console.WriteLine("Máš více než krupier, vyhrál jsi! !)");

                                                Hrac1.Penize += dabl;
                                                }
                                                // Pokud si hráč lízne a překročí 21, prohrál
                                                else if (Balicek.CountCards(HracLiznuteKarty) > 21)
                                                {

                                                    hit = false;

                                                    Balicek.KartyRuka(HracLiznuteKarty);
                                                    Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(HracLiznuteKarty));

                                                    Console.WriteLine("Máš přes 21, prohál jsi! :(");
                                                    Hrac1.Penize -= dabl;
                                                }
                                                // Pokud si dealer lízne a překročí 21, prohrál
                                                else if (Balicek.CountCards(DealerLiznuteKarty) > 21)
                                                {
                                                    Console.WriteLine("Krupier má přes 21, vyhrál jsi! :) ");
                                                    Hrac1.Penize += dabl;

                                                }
                                                // Pokud má dealer dohromady 21, vyhrál
                                                else if (Balicek.CountCards(DealerLiznuteKarty) == 21 && Balicek.CountCards(DealerLiznuteKarty) != Balicek.CountCards(HracLiznuteKarty))
                                                {
                                                    Console.WriteLine("Krupier ma 21, prohrál jsi! :(");
                                                    Hrac1.Penize -= dabl;
                                                }
                                                else if (Balicek.CountCards(DealerLiznuteKarty) > Balicek.CountCards(HracLiznuteKarty) && Balicek.CountCards(DealerLiznuteKarty) < 21)
                                                {
                                                    Console.WriteLine("Dealer má více, prohrál jsi! :(");
                                                    Hrac1.Penize -= dabl;

                                                }
                                                else if (Balicek.CountCards(DealerLiznuteKarty) == Balicek.CountCards(HracLiznuteKarty))
                                                {
                                                    Console.WriteLine("Remíza");
                                                }


                                                Console.WriteLine("Stiskni libovolnou klávesu");
                                                Console.ReadLine();
                                                break;


                                                break;
                                            // když hráč vybere stand, krupiér začne lízat karty dokud nemá více než hráč a nepřekročil 21;
                                            case "s":

                                                hit = false;
                                                // Dealer líže, dokud nemá hodnotu v ruce větší než 16
                                                while (Balicek.CountCards(DealerLiznuteKarty) <= 16)
                                                {

                                                    List<string> addingggg = Balicek.Lizni(Balicek.ShowDeck(), 1);

                                                    DealerLiznuteKarty.AddRange(addingggg);

                                                }

                                                Balicek.KartyRuka(HracLiznuteKarty);
                                                Balicek.KartyKrup(DealerLiznuteKarty);

                                                Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(HracLiznuteKarty));
                                                Console.WriteLine("Součet dealerových karet je: " + Balicek.CountCards(DealerLiznuteKarty));

                                                // Podmínky pro určení vítěze

                                                if (Balicek.CountCards(HracLiznuteKarty) > Balicek.CountCards(DealerLiznuteKarty))
                                                {
                                                    hit = false;


                                                    Console.WriteLine("Máš více než krupier, vyhrál jsi :)!");

                                                    Hrac1.Penize += sazka;
                                                }
                                                else if (Balicek.CountCards(DealerLiznuteKarty) > 21)
                                                {
                                                    Console.WriteLine("Krupier má přes 21, vyhrál jsi! :) ");
                                                    Hrac1.Penize += sazka;

                                                }
                                                else if (Balicek.CountCards(DealerLiznuteKarty) == 21)
                                                {
                                                    Console.WriteLine("Krupier ma blackjack, prohrál jsi! :(");
                                                    Hrac1.Penize -= sazka;
                                                }
                                                // pokud má dealer více než hráč, a hráč nemá v ruce více než 21, dealer vyhrál

                                                else if (Balicek.CountCards(DealerLiznuteKarty) > Balicek.CountCards(HracLiznuteKarty) && Balicek.CountCards(DealerLiznuteKarty) < 21)
                                                {
                                                    Console.WriteLine("Dealer má více, prohrál jsi! :(");
                                                    Hrac1.Penize -= sazka;
                                                    
                                                } else if (Balicek.CountCards(DealerLiznuteKarty) == Balicek.CountCards(HracLiznuteKarty))
                                                {
                                                    Console.WriteLine("Remíza");
                                                }


                                                Console.WriteLine("Stiskni libovolnou klávesu");
                                                Console.ReadLine();
                                                break;


                                            
                                            default:
                                                Console.WriteLine("Vyber z nabídky!");
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNemáš dost peněz!");
                            }
                                break;
                    case "z":
                        Hra.DisplayLeaderboard();
                        break;
                    case "j":
                        Console.WriteLine("Cíl hry je se co nejblíže přiblížit součtem karet k 21. Pokud ho překročíš, automaticky prohráváš.");
                        break;
                    case "o":
                        Console.WriteLine("Black Jack (nebo též Blackjack) je jednou z nejoblíbenějších a nejrozšířenějších karetních her, s kterou se můžete v kasinu setkat. Black Jack je vyhledáván hráči, kteří se nespokojí pouze s tím, aby výsledek hry závisel čistě na náhodě. Naopak, mohou a chtějí svou šanci na výhru ovlivnit vhodně zvolenou strategií. Při nejlepším způsobu hry je dokonce možné nad krupiérem získat určitou výhodu, což je u jiných her jev prakticky nevídaný.");
                        break;
                    case "e":
                        Console.WriteLine("Chcete uložit vaše poslední skore?\n(Y/N)");
                        string volbba = Console.ReadLine().ToLower();
                        switch (volbba)
                        {
                            case "y":
                                Hra.WriteToLeaderboard(username, Hrac1.Penize);
                                Console.WriteLine("Uloženo");
                                break;
                            case "n":
                                Console.WriteLine("Sbohem");
                                break;
                            default:
                                Console.WriteLine("Vyber z nabídky! :(");
                                break;
                        }
                        Game = false;
                        Console.WriteLine("Sbohem... :(");
                        break;
                }

            }
        }
    // Funkce na vytvoření csv souboru a zapsání hodnot do souboru
    internal static bool WriteToLeaderboard(string jmeno, int bank)
    {
        string FileName = "../../../leaderboard.csv";
        string personDetail = jmeno + "," + bank + Environment.NewLine;

        if (!File.Exists(FileName)){
            string clientHeader = Environment.NewLine;

            File.WriteAllText(FileName, clientHeader);
        }

        File.AppendAllText(FileName, personDetail);

        return true;
    }

    // Funkce na zobrazení dat z csv souboru
    internal static void DisplayLeaderboard()
    {
        string[] leaderboard = System.IO.File.ReadAllLines(@"../../../leaderboard.csv");
        foreach(string line in leaderboard)
        {
            Console.WriteLine(line);
        }
    }
    }
    
}

