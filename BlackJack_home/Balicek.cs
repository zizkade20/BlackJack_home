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
                "2", "3","4","5","6","7","8","9","10","J","Q","K","A",
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
            List<string> PlayerCards = new List<string>();
            List<string> DealerCards = new List<string>();

            foreach (var i in Deck)
            {
                DeckOfCards.Add(i.VratNazevKarty());
            }


            int index = random.Next(DeckOfCards.Count);
            int indexx = random.Next(DeckOfCards.Count);
            PlayerCards.Add(DeckOfCards[index]);
            DealerCards.Add(DeckOfCards[indexx]);

            int summH = 0;
            int summD = 0;

            foreach (string kartos in PlayerCards)
            {
                switch (DeckOfCards[index])
                {
                    case "A♣" or "A♥" or "A♦" or "A♠":
                        if (summH > 11)
                        {
                            summH = 1;
                        }
                        else
                        {
                            summD = 11;
                        }
                        break;
                    case "2♣" or "2♥" or "2♦" or "2♠":
                        summH = 2;
                        break;
                    case "3♣" or "3♥" or "3♦" or "3♠":
                        summH = 3;
                        break;
                    case "4♣" or "4♥" or "4♦" or "4♠":
                        summH = 4;
                        break;
                    case "5♣" or "5♥" or "5♦" or "5♠":
                        summH = 5;
                        break;
                    case "6♣" or "6♥" or "6♦" or "6♠":
                        summH = 6;
                        break;
                    case "7♣" or "7♥" or "7♦" or "7♠":
                        summH = 7;
                        break;
                    case "8♣" or "8♥" or "8♦" or "8♠":
                        summH = 8;
                        break;
                    case "9♣" or "9♥" or "9♦" or "9♠":
                        summH = 9;
                        break;
                    case "10♣" or "10♥" or "10♦" or "10♠":
                        summH = 10;
                        break;
                    case "J♣" or "J♥" or "J♦" or "J♠":
                        summH = 11;
                        break;
                    case "Q♣" or "Q♥" or "Q♦" or "Q♠":
                        summH = 11;
                        break;
                    case "K♣" or "K♥" or "K♦" or "K♠":
                        summH = 11;
                        break;
                }
            }
            foreach (string kartoss in DealerCards)
            {
                switch (DeckOfCards[index])
                {
                    case "A♣" or "A♥" or "A♦" or "A♠":
                        if (summH > 11)
                        {
                            summH = 1;
                        }
                        else
                        {
                            summD = 11;
                        }
                        break;
                    case "2♣" or "2♥" or "2♦" or "2♠":
                        summH = 2;
                        break;
                    case "3♣" or "3♥" or "3♦" or "3♠":
                        summH = 3;
                        break;
                    case "4♣" or "4♥" or "4♦" or "4♠":
                        summH = 4;
                        break;
                    case "5♣" or "5♥" or "5♦" or "5♠":
                        summH = 5;
                        break;
                    case "6♣" or "6♥" or "6♦" or "6♠":
                        summH = 6;
                        break;
                    case "7♣" or "7♥" or "7♦" or "7♠":
                        summH = 7;
                        break;
                    case "8♣" or "8♥" or "8♦" or "8♠":
                        summH = 8;
                        break;
                    case "9♣" or "9♥" or "9♦" or "9♠":
                        summH = 9;
                        break;
                    case "10♣" or "10♥" or "10♦" or "10♠":
                        summH = 10;
                        break;
                    case "J♣" or "J♥" or "J♦" or "J♠":
                        summH = 11;
                        break;
                    case "Q♣" or "Q♥" or "Q♦" or "Q♠":
                        summH = 11;
                        break;
                    case "K♣" or "K♥" or "K♦" or "K♠":
                        summH = 11;
                        break;
                }
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

            Console.WriteLine("Součet vašich karet je: " + summH);
            
            /*
            foreach (var i in Deck)
            {
                Console.WriteLine(i.VratNazevKarty());
            }
            */
        }

        

        internal void DealCard()
        {
            
        }


        internal void Shuffle()
        {
            

            


        }


    }







}












