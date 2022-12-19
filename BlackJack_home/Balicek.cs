using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack
{
    internal class Balicek
    {
        internal List<Karta> Deck;



        internal void CreateDeck()
        {
            List<Karta> Deck = new List<Karta>();

            List<string> symboly = new List<string>()
            {
                "♥", "♦", "♣", "♠"
            };
            List<string> hodnoty = new List<string>()
            {
                "2","3","4","5","6","7","8","9","10","J","Q","K","A",
            };
            foreach (string symbol in symboly)
            {
                foreach (string hodnota in hodnoty)
                {
                    Deck.Add(new Karta(hodnota, symbol));

                }
                
            }



            var random = new Random();
            List<string> DeckOfCards = new List<string>();
            

            foreach (var i in Deck)
            {
                DeckOfCards.Add(i.VratNazevKarty());
            }


            List<string> PlayerCards = new List<string>();
            List<string> DealerCards = new List<string>();
            Random ran = new Random();

            for (int i = 0; i < 1; i++)
            {
                int num = ran.Next(DeckOfCards.Count);

                PlayerCards.Add(DeckOfCards[num]);
                DeckOfCards.RemoveAt(num);

            }
            

            
            int indexh1 = random.Next(DeckOfCards.Count);
            int indexh2 = random.Next(DeckOfCards.Count);

            int indexd1 = random.Next(DeckOfCards.Count);
            int indexd2 = random.Next(DeckOfCards.Count);
            

            PlayerCards.Add(DeckOfCards[indexh1]);
            
            DealerCards.Add(DeckOfCards[indexd1]);
            
            Hrac Hrac1 = new Hrac();

            Console.WriteLine("Zadej sazku:");
            int sazka = Int32.Parse(Console.ReadLine());
            Hrac1.Penize -= sazka;

            int summH = 0;
            int summD = 0;
            bool hit = true;
            while (hit)
            {

                foreach (var j in PlayerCards)
                {
                    switch (j)
                    {
                        case "A♣" or "A♥" or "A♦" or "A♠":
                            if (summH > 11)
                            {
                                summH = +1;
                            }
                            else
                            {
                                summH = +11;
                            }
                            break;
                        case "2♣" or "2♥" or "2♦" or "2♠":
                            summH = +2;
                            break;
                        case "3♣" or "3♥" or "3♦" or "3♠":
                            summH = +3;
                            break;
                        case "4♣" or "4♥" or "4♦" or "4♠":
                            summH = +4;
                            break;
                        case "5♣" or "5♥" or "5♦" or "5♠":
                            summH = +5;
                            break;
                        case "6♣" or "6♥" or "6♦" or "6♠":
                            summH = +6;
                            break;
                        case "7♣" or "7♥" or "7♦" or "7♠":
                            summH = +7;
                            break;
                        case "8♣" or "8♥" or "8♦" or "8♠":
                            summH = +8;
                            break;
                        case "9♣" or "9♥" or "9♦" or "9♠":
                            summH = +9;
                            break;
                        case "10♣" or "10♥" or "10♦" or "10♠":
                            summH = +10;
                            break;
                        case "J♣" or "J♥" or "J♦" or "J♠":
                            summH = +11;
                            break;
                        case "Q♣" or "Q♥" or "Q♦" or "Q♠":
                            summH = +11;
                            break;
                        case "K♣" or "K♥" or "K♦" or "K♠":
                            summH = +11;
                            break;
                    }
                }

                
                if (summH > 21)
                {
                    hit = false;
                    Console.WriteLine("Prohrál jsi, máš přes 21");

                }
                if (summD > 21) {
                    hit = false;
                    Console.WriteLine("Vyhral Jsi, dealer má přes 21");
                    Hrac1.Penize += sazka;
                }

                
                foreach (var k in DealerCards)
                {
                    switch (k)
                    {
                        case "A♣" or "A♥" or "A♦" or "A♠":
                            if (summD > 11)
                            {
                                summD =+ 1;
                            }
                            else {
                                summD =+ 11;
                            }
                            break;
                        case "2♣" or "2♥" or "2♦" or "2♠":
                            summD =+ 2;
                            break;
                        case "3♣" or "3♥" or "3♦" or "3♠":
                            summD =+3;
                            break;
                        case "4♣" or "4♥" or "4♦" or "4♠":
                            summD =+ 4;
                            break;
                        case "5♣" or "5♥" or "5♦" or "5♠":
                            summD =+ 5;
                            break;
                        case "6♣" or "6♥" or "6♦" or "6♠":
                            summD =+ 6;
                            break;
                        case "7♣" or "7♥" or "7♦" or "7♠":
                            summD =+ 7;
                            break;
                        case "8♣" or "8♥" or "8♦" or "8♠":
                            summD =+ 8;
                            break;
                        case "9♣" or "9♥" or "9♦" or "9♠":
                            summD =+ 9;
                            break;
                        case "10♣" or "10♥" or "10♦" or "10♠":
                            summD =+ 10;
                            break;
                        case "J♣" or "J♥" or "J♦" or "J♠":
                            summD =+ 11;
                            break;
                        case "Q♣" or "Q♥" or "Q♦" or "Q♠":
                            summD =+ 11;
                            break;
                        case "K♣" or "K♥" or "K♦" or "K♠":
                            summD =+ 11;
                            break;
                    }
                }
                                
                // AHOJ
                Console.WriteLine("Zůstatek: " + Hrac1.Penize + "$\n");
                

                Console.Write("Vase Karty: ");
                foreach (var j in PlayerCards)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
                Console.Write("Krupierovy Karty: ");
                foreach (var k in DealerCards)
                {
                    Console.Write(k + " ");
                }
                Console.WriteLine();

                

                Console.WriteLine("\nSoučet vašich karet je: " + summH);
                Console.WriteLine("Součet dealerových karet je: " + summD);

                

                Console.WriteLine("\nChcete líznout další kartu? (Y/N)");
                string volba = Console.ReadLine().ToLower();
                switch (volba)
                {
                    case "y":
                        //PlayerCards.Add(DeckOfCards[indexh2]);
                        for (int i = 0; i < 1; i++)
                        {
                            int num = ran.Next(DeckOfCards.Count);

                            PlayerCards.Add(DeckOfCards[num]);
                            DeckOfCards.RemoveAt(num);

                        }
                        if (summH > 21)
                        {
                            hit = false;
                            Console.WriteLine("Máš přes 21, prohál jsi! :(");
                        }

                        break;
                    case "n":
                        hit = false;

                        if (summH == 21)
                        {
                            Console.WriteLine("Máš blackjack gratuluji! :)");
                            Hrac1.Penize += 2*sazka;
                        }
                        
                        else
                        {
                            while (summD < summH && summH! > 21)
                            {
                                //DealerCards.Add(DeckOfCards[indexd2++]);

                                for (int i = 0; i < 1; i++)
                                {
                                    int num = ran.Next(DeckOfCards.Count);

                                    DealerCards.Add(DeckOfCards[num]);
                                    DeckOfCards.RemoveAt(num);

                                }

                                Console.Write("Vase Karty: ");
                                foreach (var j in PlayerCards)
                                {
                                    Console.Write(j + " ");
                                }
                                Console.WriteLine();
                                Console.Write("Krupierovy Karty: ");
                                foreach (var k in DealerCards)
                                {
                                    Console.Write(k + " ");
                                }
                                Console.WriteLine();

                                Console.WriteLine("\nSoučet vašich karet je: " + summH);
                                Console.WriteLine("Součet dealerových karet je: " + summD);

                                if (summD > 21)
                                {
                                    Console.WriteLine("Dealer má přes 21, vyhrál jsi! :) ");
                                    Hrac1.Penize += 2*sazka;
                                }
                                else if (summD > summH && summD! > 21)
                                {
                                    Console.WriteLine("Dealer má více, prohrál jsi! :(");
                                }
                                
                            }
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
        /*
        internal int CountCards(List<Karta> Karty)
        {
            int summH = 0;

            foreach (var j in Karty)
            {
                switch (j.Hodnota)
                {
                    case "A":
                        if (summH > 11)
                        {
                            summH = +1;
                        }
                        else
                        {
                            summH = +11;
                        }
                        break;
                    case "2":
                        summH = +2;
                        break;
                    case "3":
                        summH = +3;
                        break;
                    case "4":
                        summH = +4;
                        break;
                    case "5":
                        summH = +5;
                        break;
                    case "6":
                        summH = +6;
                        break;
                    case "7":
                        summH = +7;
                        break;
                    case "8":
                        summH = +8;
                        break;
                    case "9":
                        summH = +9;
                        break;
                    case "10":
                        summH = +10;
                        break;
                    case "J":
                        summH = +11;
                        break;
                    case "Q":
                        summH = +11;
                        break;
                    case "K":
                        summH = +11;
                        break;
                }
            }
            return summH;
        }
        */
  
    }


}

/* 
namespace BlackJack
{
    internal class Balicek
    {
        internal List<Karta> Deck;
        private string[] strings1;
        private string[] strings2;

        public Balicek(string[] strings1, string[] strings2)
        {
            this.strings1 = strings1;
            this.strings2 = strings2;
        }

        internal void CreateDeck(string[] symboly, string[] hodnoty)
        {
            List<Karta> Deck = new List<Karta>();


            foreach (string symbol in symboly)
            {
                foreach (string hodnota in hodnoty)
                {
                    Deck.Add(new Karta(hodnota, symbol));

                }

            }

        }
        internal List<Karta> Lizni(int Pocet) {

            List<string> DeckOfCards = new List<string>();

            foreach (var i in Deck)
            {
                DeckOfCards.Add(i.VratNazevKarty());
            }


            List<string> PlayerCards = new List<string>();
            List<string> DealerCards = new List<string>();

            Random ran = new Random();

            for (int i = 0; i < 2; i++)
            {
                int num = ran.Next(DeckOfCards.Count);

                PlayerCards.Add(DeckOfCards[num]);
                DeckOfCards.RemoveAt(num);

            }
            return PlayerCards;
        }

            
        internal void Zkontrolovat() { 
            Hrac Hrac1 = new Hrac();

            Console.WriteLine("Zadej sazku:");
            int sazka = Int32.Parse(Console.ReadLine());
            Hrac1.Penize -= sazka;

            int summH = 0;
            int summD = 0;
            bool hit = true;
            while (hit)
            {


                // AHOJ
                Console.WriteLine("Zůstatek: " + Hrac1.Penize + "$\n");


                Console.Write("Vase Karty: ");
                foreach (var j in PlayerCards)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
                Console.Write("Krupierovy Karty: ");
                foreach (var k in DealerCards)
                {
                    Console.Write(k + " ");
                }
                Console.WriteLine();



                Console.WriteLine("\nSoučet vašich karet je: " + summH);
                Console.WriteLine("Součet dealerových karet je: " + summD);



                Console.WriteLine("\nChcete líznout další kartu? (Y/N)");
                string volba = Console.ReadLine().ToLower();
                switch (volba)
                {
                    case "y":
                        //PlayerCards.Add(DeckOfCards[indexh2]);
                        for (int i = 0; i < 1; i++)
                        {
                            int num = ran.Next(DeckOfCards.Count);

                            PlayerCards.Add(DeckOfCards[num]);
                            DeckOfCards.RemoveAt(num);

                        }
                        if (summH > 21)
                        {
                            hit = false;
                            Console.WriteLine("Máš přes 21, prohál jsi! :(");
                        }

                        break;
                    case "n":
                        hit = false;

                        if (summH == 21)
                        {
                            Console.WriteLine("Máš blackjack gratuluji! :)");
                            Hrac1.Penize += 2 * sazka;
                        }

                        else
                        {
                            while (summD < summH && summH! > 21)
                            {
                                //DealerCards.Add(DeckOfCards[indexd2++]);

                                Console.Write("Vase Karty: ");
                                foreach (var j in PlayerCards)
                                {
                                    Console.Write(j + " ");
                                }
                                Console.WriteLine();
                                Console.Write("Krupierovy Karty: ");
                                foreach (var k in DealerCards)
                                {
                                    Console.Write(k + " ");
                                }
                                Console.WriteLine();

                                Console.WriteLine("\nSoučet vašich karet je: " + summH);
                                Console.WriteLine("Součet dealerových karet je: " + summD);

                                if (summD > 21)
                                {
                                    Console.WriteLine("Dealer má přes 21, vyhrál jsi! :) ");
                                    Hrac1.Penize += 2 * sazka;
                                }
                                else if (summD > summH && summD! > 21)
                                {
                                    Console.WriteLine("Dealer má více, prohrál jsi! :(");
                                }

                            }
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
         internal int CountCards(List<Karta> Karty)
         {
             int summH = 0;

             foreach (var j in Karty)
             {
                 switch (j.Hodnota)
                 {
                     case "A":
                         if (summH > 11)
                         {
                             summH = +1;
                         }
                         else
                         {
                             summH = +11;
                         }
                         break;
                     case "2":
                         summH = +2;
                         break;
                     case "3":
                         summH = +3;
                         break;
                     case "4":
                         summH = +4;
                         break;
                     case "5":
                         summH = +5;
                         break;
                     case "6":
                         summH = +6;
                         break;
                     case "7":
                         summH = +7;
                         break;
                     case "8":
                         summH = +8;
                         break;
                     case "9":
                         summH = +9;
                         break;
                     case "10":
                         summH = +10;
                         break;
                     case "J":
                         summH = +11;
                         break;
                     case "Q":
                         summH = +11;
                         break;
                     case "K":
                         summH = +11;
                         break;
                 }
             }
             return summH;
         }

    }


}
*/








