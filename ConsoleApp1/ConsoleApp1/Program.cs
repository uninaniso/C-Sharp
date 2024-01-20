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
            int n;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("input ");

            while((n = Convert.ToInt32(Console.ReadLine())) > 100 || n < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Error ");
                if (n > 100) Console.WriteLine($"Error {n} > 100");
                else Console.WriteLine($"Error {n} < 0");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Great! Here is your result");

            Console.ForegroundColor = ConsoleColor.White;

            if (n % 3 == 0 && n % 5 == 0) Console.WriteLine("FizzBuzz");
            else if (n % 3 == 0) Console.WriteLine("Fizz");
            else if (n % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine(n);
        }
    }
}
