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
            var iprimary = new PDPrimaryNumbers.PrimaryNum();

            for (int i = 1; i <= 1000; i++)
            {
                if (iprimary.IsPrimary(i))
                    Console.WriteLine(i);
            }

            //int N = 1;

            //for (int i = 2; i < 1000; i++)
            //{
            //    if (iprimary.FermaCriterium(i) && ! iprimary.SimpleCriterium(i))
            //        Console.WriteLine(i);
            //}

            Console.ReadLine();
        }
    }
}
