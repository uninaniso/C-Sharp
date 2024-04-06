#if !DEBUG
#define SWITCH_ON
#endif

#if SWITCH_ON
#define SWITCH_ON_OUTPUT_HAS_ERROR
#define THROW_EXECPTION
#endif

using ConsoleApp.Expenses;
using System;

#if SWITCH_ON
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
#endif


namespace ConsoleApp
{
    internal class Program
    {
#if THROW_EXECPTION
        internal class OverloadingMainException : Exception
        {
            public OverloadingMainException() : base("Overloading main more than 10 times")
            {
                
            }
        }
#endif

#if SWITCH_ON
#pragma warning disable CS0028
#endif
        static void Main(string[] args) { Main(); }

        static void Main(int reloadMax = 0)
        {

            ExpenseTracker ext = new();
            int option = 0;
#if THROW_EXECPTION
            bool hasProgramError = false;
            bool hasFatalError = false;
#endif
            bool exit = false;

            do
            {
                Console.Write("input:");
                Console.ForegroundColor = ConsoleColor.Cyan;

                try
                {
                    option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("");
                            {
                                (int sum, TypesCategory category, DateTime? date, string name) items;
                                Console.Write("input sum!\ninput:");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                items.sum = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("input category!\ninput:");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                string type = Console.ReadLine();
                                if (type == "Housing") items.category = TypesCategory.Housing;
                                else if (type == "Food") items.category = TypesCategory.Food;
                                else if (type == "Transportation") items.category = TypesCategory.Transportation;
                                else if (type == "Healthcare" || type == "Medical") items.category = TypesCategory.Healthcare_And_Medical;
                                else if (type == "Entertainment") items.category = TypesCategory.Entertainment;
                                else if (type == "Clothing" || type == "Footwear") items.category = TypesCategory.Clothing_And_Footwear;
                                else if (type == "Education") items.category = TypesCategory.Education;
                                else items.category = TypesCategory.Other;

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("input date!\ninput:");
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                try
                                {
                                    items.date = Convert.ToDateTime(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    items.date = null;
                                }


                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("input name!\ninput:");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                items.name = Console.ReadLine();

                                ext.Add(items.sum, items.category, items.date, items.name);
                            }
                            break;
                        case 2:
                            {
                                (int index, int sum, TypesCategory category) items;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("input index!\ninput:");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                items.index = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("input sum!\ninput:");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                items.sum = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("input category!\ninput:");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                string type = Console.ReadLine();
                                if (type == "Housing") items.category = TypesCategory.Housing;
                                else if (type == "Food") items.category = TypesCategory.Food;
                                else if (type == "Transportation") items.category = TypesCategory.Transportation;
                                else if (type == "Healthcare" || type == "Medical") items.category = TypesCategory.Healthcare_And_Medical;
                                else if (type == "Entertainment") items.category = TypesCategory.Entertainment;
                                else if (type == "Clothing" || type == "Footwear") items.category = TypesCategory.Clothing_And_Footwear;
                                else if (type == "Education") items.category = TypesCategory.Education;
                                else items.category = TypesCategory.Other;

                                ext.Edit(items.index, items.sum, items.category);
                            }
                            continue;

                        case 3:
                            int index;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("input index!\ninput:");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            index = int.Parse(Console.ReadLine());
                            ext.Remove(index);
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("error");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            continue;
                    }
                }

                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fatal error!");
                    Console.WriteLine($"Description for FormatException [{e.Message}]");
                    Console.WriteLine("Program is will reload");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (reloadMax < 10) Main(reloadMax++);
#if THROW_EXECPTION
                    else throw new OverloadingMainException();
#endif
                }

#if SWITCH_ON_OUTPUT_HAS_ERROR
                finally
                {
                    Console.Write("program error ");
                    if (hasProgramError)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("OK");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }


                    Console.Write("fatal error ");
                    if (hasFatalError)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("OK");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("no found errors");
                Console.WriteLine("program is work!");
                Console.ForegroundColor = ConsoleColor.Cyan;
#endif
            }

            while (exit is not true);
        }
    }
}
