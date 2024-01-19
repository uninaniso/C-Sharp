using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    int j = n / i;
                    Console.WriteLine($"{i} * {j} = {n}");
                }
            }
        }
    }
}
