using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PickUniqueCardsUI
{
    class CardPicker
    {
        static Random random = new Random();
        static string[] cards = new string[52];

        static CardPicker()
        {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            int cardCounter = 0;

            for (int cardVal = 1; cardVal <= 13; cardVal++)
            {
                foreach (string cardSuit in suits)
                {
                    string cardName;

                    if (cardVal == 1)
                    {
                        cardName = "Ace";
                    } 
                    else if (cardVal == 11)
                    {
                        cardName = "Jack";
                    }
                    else if (cardVal == 12)
                    {
                        cardName = "Queen";
                    }
                    else if (cardVal == 13)
                    {
                        cardName = "King";
                    }
                    else
                    {
                        cardName = cardVal.ToString();
                    }

                    cards[cardCounter++] = cardName + " of " + cardSuit;
                }
            }
        }

        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            for (int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomCard();
            }
            return pickedCards;
        }

        private static string RandomCard()
        {
            int cardNum = random.Next(cards.Length);

            string picked = cards[cardNum];

            cards = cards.Where(e => e != picked).ToArray();

            return picked;
        }
    }
}
