using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public int Value { get; set; }
        public int Suit { get; set; }

        //Card constructor that takes integers as parameters and sets the values of the cards
        public Card(int value, int suit)
        {
            //These if statements check if the value being set is in the correct range
            //for example there are 13 values for the card so it makes sures only values
            //between 0 and 12 are set.
            if (value < 0 || value > 12)
            {
                throw new ArgumentException("Value must be between 1 and 13");
            }
            Value = value;
            if (suit < 0 || suit > 3)
            {
                throw new ArgumentException("Suit must be between 1 and 4");
            }
            Suit = suit;
        }
        //Converts the card object to string so that it can be printed to the terminal
        //with the addition of face values
        //This is an additional method 
        public override string ToString()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            //Return the string representation of the string
            return ($"{values[Value]} of {suits[Suit]}");
        }
    }
}
