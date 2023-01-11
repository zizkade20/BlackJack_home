using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack
{
    internal class Balicek
    {
        internal List<Karta> Deck = new List<Karta>();


        // Funkce vytvoří balíček a naplní ho kartami
        internal static List<Karta> CreateDeck()
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
            return Deck;

        }
        internal static List<string> ShowDeck() { 

            var random = new Random();
            List<string> DeckOfCards = new List<string>();


            foreach (var i in Balicek.CreateDeck())
            {
                DeckOfCards.Add(i.VratNazevKarty());
            }
            return DeckOfCards;
        }

        internal static List<string> Lizni(List<string> Karty, int Pocet) { 

            Random ran = new Random();
            List<string> Ruka = new List<string>();
            // naplnění ruky kartami
            for (int i = 0; i < Pocet; i++)
            {
                int num = ran.Next(Karty.Count);

                Ruka.Add(Balicek.ShowDeck()[num]);
                Karty.RemoveAt(num);

            }
            return Ruka;
            // while běží dokud hráč líže
        }
        // Funkce na počítání hodnoty karet
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

        // Funkce na zobrazení hráčových karet
        internal static void KartyRuka(List<string> Karty)
        {
            Console.Write("Vase Karty: ");
            foreach (var j in Karty)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }

        // Funkce na zobrazení krupierových karet
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

