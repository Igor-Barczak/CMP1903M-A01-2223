using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        public static List<Card> pack = new List<Card>();


        static Pack()
        {
            //Initialise the card pack here
            for(int suit = 0; suit < 4; suit++)
            {
                for(int value = 0; value < 13; value++)
                {
                    pack.Add(new Card(value, suit));
                }
            }
            

        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            return false;
        }
        public static Card deal()
        {
            //Deals one card
            Card card = pack[0];
            pack.RemoveAt(0);
            return card;
        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            int cardsLeft = pack.Count;
            List<Card> drawnCards = new List<Card>();

            for (int i = 0; i < amount; i++)
            {
                if (amount > cardsLeft)
                {
                    throw new ArgumentException("Cannot deal more cards than left in the pack");
                }
                drawnCards.Add(Pack.deal());

            }
            return drawnCards;
        }
    }
}
