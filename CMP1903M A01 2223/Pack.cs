using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            Random random = new Random();
            switch(typeOfShuffle)
            {
                //Fisher-Yates Shuffle
                case 1:
                    //This loop starts from the last element and iterates through each card one by one
                    //and swaps it to create a random order
                    for (int i = pack.Count - 1; i > 0; --i)
                    {
                        int j = random.Next(i + 1);
                        Card temp = pack[j];
                        pack[j] = pack[i];
                        pack[i] = temp;
                    }
                    return true;
                case 2:
                    int half = pack.Count / 2;
                    List<Card> topHalf = pack.GetRange(0, half);
                    List<Card> bottomHalf = pack.GetRange(half, half);
                    List<Card> shuffledPack = new List<Card>();
                    while(topHalf.Count > 0  && bottomHalf.Count > 0)
                    {
                        int randNum = random.Next(1, 100);
                        if(randNum <= 50)
                        {
                            shuffledPack.Add(topHalf[0]);
                            topHalf.RemoveAt(0);
                        }
                        else
                        {
                            shuffledPack.Add(bottomHalf[0]);
                            bottomHalf.RemoveAt(0);
                        }
                    }
                    shuffledPack.AddRange(topHalf);
                    shuffledPack.AddRange(bottomHalf);
                    pack = shuffledPack;
                    return true;


                default:
                    return false;
            }
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
