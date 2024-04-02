using ConsoleApp.Expenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;


namespace ConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {

            ExpenseTracker ext = new();
            int option = 0;
            while (true)
            {
                Console.WriteLine("input:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                option = Console.Read();

                switch (option)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("");
                        (int sum, TypesCategory category, DateTime? date, string name) items;
                        Console.WriteLine("input sum!\ninput:");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        items.sum = Console.Read();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("input category!\ninput:");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        try
                        {
                            string type = Console.ReadLine();
                            if (type == "Housing") items.category = TypesCategory.Housing;
                            else if (type == "Food") items.category = TypesCategory.Food;
                            else if (type == "Transportation") items.category = TypesCategory.Transportation;
                            else if (type == "Healthcare" || type == "Medical") items.category = TypesCategory.Healthcare_And_Medical;
                            else if (type == "Entertainment") items.category = TypesCategory.Entertainment;
                            else if (type == "Clothing" || type == "Footwear") items.category = TypesCategory.Clothing_And_Footwear;
                            else if (type == "Education") items.category = TypesCategory.Education;
                            else items.category = TypesCategory.Other;
                        }
                        finally
                        {
                            items.category = TypesCategory.Other;
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("input date!\ninput:");
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        try
                        {
                            items.date = Convert.ToDateTime(Console.ReadLine());
                        }
                        finally
                        {
                            items.date = null;
                        }


                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("input name!\ninput:");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        items.name = Console.ReadLine();

                        ext.Add(items.sum,items.category, items.date, items.name);
                        break;
                    case 2:
                        //ext.
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("error");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        continue;
                }
            }
        }
    }
}
