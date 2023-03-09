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
            string typeOfShuffle = Console.ReadLine();

            //Additional error handling for when a user does not input a valid value type
            int shuffleType;
            //This if statement checks if it can convert the input to an integer value
            //If the TryParse method returns false an argument exception will be thrown
            if (!int.TryParse(typeOfShuffle, out shuffleType))
            {
                throw new ArgumentException("Invalid value for typeOfShuffle parameter. The value must be an integer.");
            }
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
            int cardsToDeal = -1;
            //Variable used to check if an input is valid
            bool isValidInput = false;
            //A loop that will continue repeating until the user inputs a valid value
            //This stops the code from crashing when an invalid input is entered
            while(!isValidInput)
            {
                Console.Write("How many cards would you like to deal? ");
                isValidInput = int.TryParse(Console.ReadLine(), out cardsToDeal);
                //Checks if the input is valid and if the number of cards to deal is within the range
                //If the isValidInput variable is false then a message is written and goes back
                //to the start of the while loop
                if (!isValidInput || cardsToDeal <= 0 || cardsToDeal > Pack.pack.Count)
                {
                    Console.WriteLine("Invalid input, enter a positive integer less than or equal to number " +
                        "of cards in the deck");
                    isValidInput = false;
                }
            }

            //Creates Card objects and deals each card from the pack using the method dealCard
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
