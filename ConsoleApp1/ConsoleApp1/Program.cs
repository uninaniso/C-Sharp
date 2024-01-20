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
            int n1, n2;

            try
            {
                Console.Write("input1: ");
                n1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("input2: ");
                n2 = Convert.ToInt32(Console.ReadLine());
            }

            catch (Exception)
            {
                n1 = 90;
                n2 = 10;
            }

            int result = (n2 * n1) / 100;

            Console.WriteLine(result);
        }
    }
}