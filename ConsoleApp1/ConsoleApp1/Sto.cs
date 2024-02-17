using System;
using ConsoleApp1.ManageDate;

namespace ConsoleApp1.UltraSto
{
    public class BoxFirst
    {
        protected static byte priceReplacingBearing = 21;
        protected static byte priceRepairEngine = 25;
        protected DateRange date;
        protected byte[] time = { 2, 3, 2, 5, 10, 59, 10, 59 };

        public byte PriceReplacingBearing { get => priceReplacingBearing; }
        public byte PriceRepairEngine { get => priceRepairEngine; }

        protected void PrintDate(int price)
        {
            Console.Write($"Required amount to ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if(price == 1) Console.WriteLine($"pay {PriceReplacingBearing}$");
            else Console.WriteLine($"pay {priceRepairEngine}$");
            Console.ForegroundColor = ConsoleColor.White;

            DateTimeOffset startTime = DateTimeOffset.UtcNow;

            Console.Write($"Date start ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{startTime}");
            Console.ForegroundColor = ConsoleColor.White;

            Random random = new Random();
            date.End = startTime
                .AddDays(random.Next(time[0], time[1]))
                .AddHours(random.Next(time[2], time[3]))
                .AddMinutes(random.Next(time[4], time[5]))
                .AddSeconds(random.Next(time[6], time[7]));

            Console.Write($"Date end ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{date.End}]");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ReplaceBearing(Car car)
        {
            Console.Write($"\nyour car is in the queue ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[{car}]");
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                Console.Write($"We work with your car ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[{car}]");
                Console.ForegroundColor = ConsoleColor.White;

                date = DateTimeOffset.UtcNow;

                PrintDate(1);

                Console.Write($"\nEnd repair for car ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{date.End}]");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"Date start ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{date.Start}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }
        }

        public void RepairEngine(Car car)
        {
            Console.Write($"\nyour car is in the queue ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[{car}]");
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                Console.Write($"We work with your car ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[{car}]");
                Console.ForegroundColor = ConsoleColor.White;

                date = DateTimeOffset.UtcNow;

                PrintDate(2);

                Console.Write($"\nEnd repair for car ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{date.End}]");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"Date start ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{date.Start}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public sealed class BoxSecond : BoxFirst
    {
        public BoxSecond()
        {
            priceReplacingBearing = 20;
            priceRepairEngine = 27;
        }
    }

    public sealed class BoxThird : BoxFirst
    {
        private static byte[] time = { 0, 2, 1, 3, 10, 40, 10, 30 };

        public BoxThird()
        {
            priceReplacingBearing = 30;
            priceRepairEngine = 32;
        }
    }

    public sealed class BoxFourth : BoxFirst
    {

        public BoxFourth()
        {
            priceReplacingBearing = 23;
            priceRepairEngine = 29;
        }
    }
}