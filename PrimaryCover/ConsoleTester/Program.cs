using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // выводим первые 100 простых чисел.
            var iprimary = new PDPrimaryNumbers.PrimaryNum();

            for (int i = 2; i < 100; i++)
            {
                if (iprimary.IsPrimary(i))
                    Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
