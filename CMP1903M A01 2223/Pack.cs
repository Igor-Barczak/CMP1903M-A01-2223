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
        //Initialises the pack
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

        //Shuffle method that takes an integer argument for type of shuffle
        //
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
                //Splits the pack in half by creating two new arrays
                //Creates another array for the shuffled cards which will replace the current pack
                case 2:
                    int half = pack.Count / 2;
                    List<Card> topHalf = pack.GetRange(0, half);
                    List<Card> bottomHalf = pack.GetRange(half, half);
                    List<Card> shuffledPack = new List<Card>();
                    //Replicates a riffle shuffle by choosing one of the temporary arrays at random and
                    //taking the top card at index 0 and adding it to the shuffledPack array
                    //until the length of the temporary arrays reaches 0
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
        //Deals a single card from the top of the pack and then removes it
        public static Card deal()
        {
            //Deals one card
            Card card = pack[0];
            pack.RemoveAt(0);
            return card;
        }
        //Deals a selected number of cards from the pack by using a for loop and calling the deal card
        //method by the amount of times passed in the argument
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
