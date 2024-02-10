using System;
using ConsoleApp1.UltraSto;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var box1 = new BoxFirst();
            var box2 = new BoxSecond();
            var box3 = new BoxThird();
            var box4 = new BoxFourth();

            ConsoleKeyInfo input = new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false);
            Random rand = new Random();

            while (true)
            {
                Console.WriteLine("box1 - 1,    box2 - 2,    "
                    + "box3 - 3,    box4 - 4,    exit - 5,");
                input = Console.ReadKey();

                if (input.Key == ConsoleKey.D5)
                    break;

                    if (input.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("enter ReplaceBearing - 1,   RepairEngine - 2");
                    input = Console.ReadKey();

                    if (input.Key == ConsoleKey.D1) box1.ReplaceBearing((Car)rand.Next(1, 70));
                    else box1.RepairEngine((Car)rand.Next(1, 70));
                }

                else if (input.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("enter ReplaceBearing - 1,   RepairEngine - 2");
                    input = Console.ReadKey();

                    if (input.Key == ConsoleKey.D1) box2.ReplaceBearing((Car)rand.Next(1, 70));
                    else box2.RepairEngine((Car)rand.Next(1, 70));
                }

                else if (input.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("enter ReplaceBearing - 1,   RepairEngine - 2");
                    input = Console.ReadKey();

                    if (input.Key == ConsoleKey.D1) box3.ReplaceBearing((Car)rand.Next(1, 70));
                    else box3.RepairEngine((Car)rand.Next(1, 70));
                }

                else
                {
                    Console.WriteLine("enter ReplaceBearing - 1,   RepairEngine - 2");
                    input = Console.ReadKey();

                    if (input.Key == ConsoleKey.D1) box4.ReplaceBearing((Car)rand.Next(1, 70));
                    else box4.RepairEngine((Car)rand.Next(1, 70));
                }
            }
        }
    }
}