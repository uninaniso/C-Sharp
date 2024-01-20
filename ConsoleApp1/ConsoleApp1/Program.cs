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
            int n1, n2, n3, n4;

            try
            {
                Console.Write("input1:");
                n1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("input2:");
                n2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("input3:");
                n3 = Convert.ToInt32(Console.ReadLine());

                Console.Write("input4:");
                n4 = Convert.ToInt32(Console.ReadLine());
            }

            catch (Exception)
            {
                n1 = 1;
                n2 = 2;
                n3 = 3;
                n4 = 4;
            }

            Console.WriteLine("result "+ n1 + n2 + n3 + n4);
        }
    }
}