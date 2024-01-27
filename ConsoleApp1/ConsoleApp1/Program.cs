using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input ");
            int i = Convert.ToInt32(Console.ReadLine());

            Console.Write("1 - c, 2 - f:");
            int j = Convert.ToInt32(Console.ReadLine());

            if (j == 1)
                Console.WriteLine("C"+5/9*(i - 32));

            else
                Console.WriteLine("F" + 5 / 9 * (i + 32));
        }
    }
}
