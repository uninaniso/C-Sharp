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

            string number;

            int n1, n2;

            try
            {
                Console.Write("input number: ");
                number = Console.ReadLine();

                if (number == string.Empty || number.Length > 6 || number.Length < 6) throw new Exception();

                else
                {
                    string str = "qwertyuiop[]{}|asdfghjkl:;'zxcvbnm,.<>/?+=-_)(*&^%$#@!~";
                    for (global::System.Int32 i = 0; i < number.Length; i++)
                    {
                        for (global::System.Int32 j = 0; j < str.Length; j++)
                        {
                            if (number[i] == str[j]) throw new Exception();
                        }
                    }
                }

                Console.Write("input1: ");
                n1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("input2: ");
                n2 = Convert.ToInt32(Console.ReadLine());

                if (n1 > 6 || n2 > 6) throw new Exception();
                else if(n1 < 1 || n2 < 1) throw new Exception();

            }

            catch (Exception)
            {
                number = "123456";
                n1 = 1;
                n2 = 6;
            }

            Console.WriteLine(number);

            Console.Write("result ");

            for (int i = 0; i < 6; i++)
            {
                if (i == n1-1) Console.Write(number[n2-1]);
                else if (i == n2-1) Console.Write(number[n1-1]);
                else Console.Write(number[i]);
            }

            Console.WriteLine();
        }
    }
}