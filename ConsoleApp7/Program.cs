using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new List<int>{7, 2, 23, 4, 123};

            var q = numbers.Where(x => x < 10);

            foreach (var number in q)
            {
                Console.WriteLine(number);
            }
        }
    }
}
