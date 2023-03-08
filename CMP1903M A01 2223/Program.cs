using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        //Program that calls the testing class to check all the methods run as intended
        static void Main(string[] args)
        {
            Testing test = new Testing();
            test.runTest();
        }
    }
}
