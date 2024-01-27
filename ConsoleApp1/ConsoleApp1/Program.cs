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
            Console.Write("input the date in the format dd.mm.yyyy: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime userInputDate))
            {
                string season = GetSeason(userInputDate.Month);
                string dayOfWeek = userInputDate.DayOfWeek.ToString();

                Console.WriteLine($"{season} {dayOfWeek}");
            }
            else
            {
                Console.WriteLine("Invalid date format!");
            }
        }

        static string GetSeason(int month)
        {
            switch (month)
            {
                case 12:
                case 1:
                case 2:
                    return "Winter";
                case 3:
                case 4:
                case 5:
                    return "Spring";
                case 6:
                case 7:
                case 8:
                    return "Summer";
                case 9:
                case 10:
                case 11:
                    return "Autumn";
                default:
                    return "Invalid Month";
            }
        }
    }
}
