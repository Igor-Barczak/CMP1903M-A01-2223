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

        public Card(int value, int suit)
        {
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

        public override string ToString()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            string suitString = suits[Suit];
            string valueString = values[Value];
            //Return the string representation of the string
            return ($"{valueString} of {suitString}");
        }
    }
}
