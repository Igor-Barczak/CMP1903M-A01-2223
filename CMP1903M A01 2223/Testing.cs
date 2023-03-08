using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Testing
    {
        //Contains all the code that calls the Pack class to create, shuffle, and deal a pack of cards
        public void runTest()
        {
            Console.Write("Enter 1 for Fisher-Yates shuffle, 2 for Riffle shuffle or 3 for no shuffle: ");
            int shuffleType = int.Parse(Console.ReadLine());

            //Chooses which shuffle to use based on user input
            switch (shuffleType)
            {
                //Fisher-Yates Shuffle
                case 1:
                    Pack.shuffleCardPack(1);
                    break;
                //Riffle Shuffle
                //This uses a while loop to shuffle the cards 7 times to make sure
                //the pack is shuffled properly
                case 2:
                    int count = 0;
                    while (count != 7)
                    {
                        Pack.shuffleCardPack(2);
                        count++;
                    }
                    break;
                //No Shuffle
                case 3:
                    break;
                default: 
                    break;
            }
            //Asks the user how many cards to deal and calls the dealCard method
            Console.Write("How many cards would you like to deal? ");
            int cardsToDeal = int.Parse(Console.ReadLine());
            List<Card> cards = Pack.dealCard(cardsToDeal);

            //prints each card drawn by iterating through the card objects
            Console.WriteLine("You drew: ");
            foreach (Card card in cards)
            {
                Console.WriteLine($"{card} ");
            }
        }
    }
}
