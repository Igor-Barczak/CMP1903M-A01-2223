using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = Pack.dealCard(13);
            foreach(Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
