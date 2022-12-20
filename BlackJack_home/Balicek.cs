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

            for (int i = 0; i < 2; i++)
            {
                int num = ran.Next(DeckOfCards.Count);

                PlayerCards.Add(DeckOfCards[num]);
                DeckOfCards.RemoveAt(num);

            }
            for (int i = 0; i < 2; i++)
            {
                int num = ran.Next(DeckOfCards.Count);

                DealerCards.Add(DeckOfCards[num]);
                DeckOfCards.RemoveAt(num);

            }


            Hrac Hrac1 = new Hrac();            
            bool hit = true;
            while (hit)
            {
                        
          
                Balicek.KartyRuka(PlayerCards);

                Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(PlayerCards));

                if (Balicek.CountCards(PlayerCards) < 21)
                {

                    Console.WriteLine("\n(H)it / (S)tand / (D)ouble");
                    string volba = Console.ReadLine().ToLower();
                    switch (volba)
                    {
                        case "h":
                            for (int i = 0; i < 1; i++)
                            {

                                int num = ran.Next(DeckOfCards.Count);

                                PlayerCards.Add(DeckOfCards[num]);
                                DeckOfCards.RemoveAt(num);

                                if (Balicek.CountCards(PlayerCards) > 21)
                                {
                                    hit = false;

                                    Balicek.KartyRuka(PlayerCards);
                                    Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(PlayerCards));

                                    Console.WriteLine("Máš přes 21, prohál jsi! :(");
                                    
                                } 
                                
                            }

                            break;

                        case "s":

                            hit = false;

                            while (Balicek.CountCards(DealerCards) <= Balicek.CountCards(PlayerCards))
                            {

                                int num = ran.Next(DeckOfCards.Count);

                                DealerCards.Add(DeckOfCards[num]);
                                DeckOfCards.RemoveAt(num);

                                
                                

                            }
                            if (Balicek.CountCards(PlayerCards) == 21)
                            {
                                hit = false;

                                Balicek.KartyRuka(PlayerCards);
                                Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(PlayerCards));

                                Console.WriteLine("Gratuluji máš Blackjack!");
                                Hrac1.Win = false;
                                Hrac1.Blackjack = true;
                                Console.WriteLine(Hrac1.Score * 4);

                            }

                            else if (Balicek.CountCards(DealerCards) == Balicek.CountCards(PlayerCards))
                            {

                                int numm = ran.Next(DeckOfCards.Count);

                                DealerCards.Add(DeckOfCards[numm]);
                                DeckOfCards.RemoveAt(numm);
                            }
                            else if (Balicek.CountCards(PlayerCards) > Balicek.CountCards(DealerCards))
                            {
                                hit = false;

                                Balicek.KartyRuka(PlayerCards);
                                Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(PlayerCards));

                                Console.WriteLine("Máš více než krupier, vyhrál jsi :)!");
                                Hrac1.Win = true;

                                Console.WriteLine(Hrac1.Score * 2);
                            }

                            Balicek.KartyRuka(PlayerCards);
                            Balicek.KartyRuka(DealerCards);

                            Console.WriteLine("\nSoučet vašich karet je: " + Balicek.CountCards(PlayerCards));
                            Console.WriteLine("Součet dealerových karet je: " + Balicek.CountCards(DealerCards));

                            if (Balicek.CountCards(DealerCards) > 21)
                            {
                                Console.WriteLine("Krupier má přes 21, vyhrál jsi! :) ");
                                Hrac1.Win = true;
                                Console.WriteLine(Hrac1.Score);
                                
                            }
                            if (Balicek.CountCards(DealerCards) == 21)
                            {
                                Console.WriteLine("Krupier ma blackjack, prohrál jsi! :(");
                                
                            }
                            else if (Balicek.CountCards(DealerCards) > Balicek.CountCards(PlayerCards) && Balicek.CountCards(DealerCards) < 21)
                            {
                                Console.WriteLine("Dealer má více, prohrál jsi! :(");
                                
                            }


                            Console.WriteLine("Stiskni libovolnou klávesu");
                            Console.ReadLine();
                            break;
                                   

                        case "d":
                            break;
                        default:
                            Console.WriteLine("Vyber z nabídky!");
                            break;
                    }
                }
                
                

            }
                

    }


        public static int CountCards(List<string> Karty)
        {
            int summD = 0;

            foreach (var k in Karty)
            {
                switch (k)
                {
                    case "A♣" or "A♥" or "A♦" or "A♠":
                        if (summD > 11)
                        {
                            summD += 1;
                        }
                        else
                        {
                            
                            summD += 11;

                        }
                        break;
                    case "2♣" or "2♥" or "2♦" or "2♠":
                        summD += 2;
                        break;
                    case "3♣" or "3♥" or "3♦" or "3♠":
                        summD += 3;
                        break;
                    case "4♣" or "4♥" or "4♦" or "4♠":
                        summD += 4;
                        break;
                    case "5♣" or "5♥" or "5♦" or "5♠":
                        summD += 5;
                        break;
                    case "6♣" or "6♥" or "6♦" or "6♠":
                        summD += 6;
                        break;
                    case "7♣" or "7♥" or "7♦" or "7♠":
                        summD += 7;
                        break;
                    case "8♣" or "8♥" or "8♦" or "8♠":
                        summD += 8;
                        break;
                    case "9♣" or "9♥" or "9♦" or "9♠":
                        summD += 9;
                        break;
                    case "10♣" or "10♥" or "10♦" or "10♠":
                        summD += 10;
                        break;
                    case "J♣" or "J♥" or "J♦" or "J♠":
                        summD += 10;
                        break;
                    case "Q♣" or "Q♥" or "Q♦" or "Q♠":
                        summD += 10;
                        break;
                    case "K♣" or "K♥" or "K♦" or "K♠":
                        summD += 10;
                        break;
                }
            }
            foreach (var ka in Karty)
            {
                switch (ka)
                {
                    case "A":
                        if (summD > 11)
                        {
                            summD += 1;
                        }
                        else
                        {
                            summD += 11;
                        }
                        break;


                }
            }

            return summD;
        }


        internal static void KartyRuka(List<string> Karty)
        {
            Console.Write("Vase Karty: ");
            foreach (var j in Karty)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }


        internal static void KartyKrup(List<string> Karty)
        {
            Console.Write("Krupierovy karty: ");
            foreach (var s in Karty)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }

    }
}

