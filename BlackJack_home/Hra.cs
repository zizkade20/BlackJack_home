using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace BlackJack
{
    internal class Hra
    {
        internal bool Game;

        class Data
        {
            public string Name { get; set; }
            public int Money { get; set; }
        }
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

            int pujcka = 0;

            Random ran = new Random();
            //vytvoření přezdívky


            Console.WriteLine("Zadejte přezdívku:");
            Console.Write("->");
            string username = Console.ReadLine();

            var Hrac1 = new Hrac(username);
            
            if (username.Length == 0)
            {
                Console.WriteLine("Jméno je prázdné, nebude se ukládat skore");
            }

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

                        if (Hrac1.Penize <= 0)
                        {
                            Console.WriteLine("Zůstatek: " + Hrac1.Penize + "$\nPřišel jste o všechny peníze, chcete hrát znovu? (Y/N)");
                            string anone = Console.ReadLine().ToLower();

                            switch (anone)
                            {
                                case "y":
                                    Hrac1.Penize = 200;
                                    break;
                                case "n":
                                    break;
                                default:
                                    break;
                            }
                        }

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

                                                if (Balicek.CountCards(HracLiznuteKarty) > 21)
                                                {

                                                    hit = false;

                                                    Balicek.KartyRuka(HracLiznuteKarty);
                                                    Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(HracLiznuteKarty));

                                                    Console.WriteLine("Máš přes 21, prohál jsi! :(");
                                                    Hrac1.Penize -= sazka;
                                                } else if (Balicek.CountCards(HracLiznuteKarty) == 21 && HracLiznuteKarty.Count > 2)
                                                {
                                                    hit = false;

                                                    Console.WriteLine("Gratuluji máš 21");

                                                    Hrac1.Penize += sazka;


                                                }
                                                break;
                                            // když hráč vybere double, dostane už jenom jednu kartu a zdvojnásobí se jeho sázka.
                                            case "d":

                                                


                                                int dabl = sazka * 2;
                                                
                                                if (Hrac1.Penize < dabl)
                                                {
                                                    Console.WriteLine("Nemáš dost peněz na double!");
                                                } else
                                                {
                                                    hit = false;
                                                
                                                
                                                    List<string> addingg = Balicek.Lizni(Balicek.ShowDeck(), 1);

                                                    HracLiznuteKarty.AddRange(addingg);
                                                    // Dealer líže, dokud nemá hodnotu v ruce větší než 16
                                                    while (Balicek.CountCards(DealerLiznuteKarty) < 16)
                                                    {

                                                        List<string> addin = Balicek.Lizni(Balicek.ShowDeck(), 1);

                                                        DealerLiznuteKarty.AddRange(addin);

                                                    }

                                                    Balicek.KartyRuka(HracLiznuteKarty);
                                                    Balicek.KartyKrup(DealerLiznuteKarty);

                                                    Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(HracLiznuteKarty));
                                                    Console.WriteLine("Součet dealerových karet je: " + Balicek.CountCards(DealerLiznuteKarty));
                                                    // Podmínky pro určení vítěze

                                                    if (Balicek.CountCards(HracLiznuteKarty) == 21 && HracLiznuteKarty.Count == 2)
                                                    {
                                                        hit = false;

                                                        Console.WriteLine("Dealer má Blackjack, prohrál jsi! :(");

                                                        Hrac1.Penize -= dabl;


                                                    }
                                                    if (Balicek.CountCards(HracLiznuteKarty) > Balicek.CountCards(DealerLiznuteKarty) && Balicek.CountCards(HracLiznuteKarty) <= 21)
                                                    {
                                                        hit = false;


                                                        Console.WriteLine("Máš více než krupier, vyhrál jsi! !)");

                                                        Hrac1.Penize += dabl;
                                                    }
                                                    else if (Balicek.CountCards(HracLiznuteKarty) > 21)
                                                    {

                                                        hit = false;

                                                        Balicek.KartyRuka(HracLiznuteKarty);
                                                        Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(HracLiznuteKarty));

                                                        Console.WriteLine("Máš přes 21, prohál jsi! :(");
                                                        Hrac1.Penize -= dabl;
                                                    }
                                                    else if (Balicek.CountCards(DealerLiznuteKarty) > 21)
                                                    {
                                                        Console.WriteLine("Krupier má přes 21, vyhrál jsi! :) ");
                                                        Hrac1.Penize += dabl;

                                                    }
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

                                                }
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
                            else if (sazka == 0)
                            {
                                Console.WriteLine("\nSázka není validní");
                            }
                            else
                            {
                                Console.WriteLine("\nNemáš dost peněz");
                            }
                                break;
                    case "z":
                        Hra.DeserializeJson();
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
                                Hra.AppendJson(username, Hrac1.Penize);
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
        internal static bool AppendJson(string jmeno, int bank)
        {
            
            var path = @"../../../leaderboard.json";

            var data = File.ReadAllText(path);



            var nData = JsonConvert.DeserializeObject<List<Data>>(data) ?? new List<Data>();

            nData.Add(new Data { Name = jmeno, Money = bank });

            data = JsonConvert.SerializeObject(nData);
            File.WriteAllText(path, data);
            

            return true;
        }

        internal static void DeserializeJson()
        {
            var path = @"../../../leaderboard.json";

           
            string json = File.ReadAllText(path);



            var dataList = JsonConvert.DeserializeObject<List<Data>>(json);

            var sorted = dataList.OrderByDescending(x => x.Money);


            Console.WriteLine("Žebříček největších borců:\n");
            if (dataList != null)
            {
                foreach(var data in sorted)
                {

                    Console.WriteLine(data.Name + "  " + data.Money);
                }
            }

        }
    }
}

