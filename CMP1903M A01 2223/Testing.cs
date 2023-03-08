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
        public void runTest()
        {
            Console.Write("Enter 1 for Fisher-Yates shuffle or 2 for Riffle shuffle or 3 for no shuffle: ");
            int shuffleType = int.Parse(Console.ReadLine());

            switch (shuffleType)
            {
                case 1:
                    Pack.shuffleCardPack(1);
                    break;
                case 2:
                    int count = 0;
                    while (count != 7)
                    {
                        Pack.shuffleCardPack(2);
                        count++;
                    }
                    break;
                case 3:
                    break;
                default: 
                    break;
            }

            Console.Write("How many cards would you like to deal? ");
            int cardsToDeal = int.Parse(Console.ReadLine());
            List<Card> cards = Pack.dealCard(cardsToDeal);

            Console.WriteLine("You drew: ");
            foreach (Card card in cards)
            {
                Console.WriteLine($"{card.ToString()} ");
            }
        }
    }
}
