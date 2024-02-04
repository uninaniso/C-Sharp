using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> tasks = new List<object>();

            int choice;
            bool Stop = true;

            while (Stop)
            {
                Console.WriteLine("1. Додати завдання");
                Console.WriteLine("2. Додати підзавдання");
                Console.WriteLine("3. Редагувати завдання");
                Console.WriteLine("4. Видалити завдання");
                Console.WriteLine("5. Переглянути завдання");
                Console.WriteLine("6. Вийти");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTask(tasks);
                        break;
                    case 2:
                        AddSubtask(tasks);
                        break;
                    case 3:
                        EditTask(tasks);
                        break;
                    case 4:
                        DeleteTask(tasks);
                        break;
                    case 5:
                        DisplayTasks(tasks);
                        break;
                    case 6:
                        Stop = false;
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void AddTask(List<object> tasks)
        {
            Console.WriteLine("Введіть назву завдання:");
            string title = Console.ReadLine();
            Console.WriteLine("Введіть опис завдання:");
            string description = Console.ReadLine();

            tasks.Add(new { Title = title, Description = description, Subtasks = new List<object>() });

            Console.WriteLine("Завдання додано успішно!");
        }

        static void AddSubtask(List<object> tasks)
        {
            Console.WriteLine("Введіть індекс завдання для додавання підзавдання:");
            int taskIndex = int.Parse(Console.ReadLine());

            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                Console.WriteLine("Введіть назву підзавдання:");
                string subtaskTitle = Console.ReadLine();
                Console.WriteLine("Введіть опис підзавдання:");
                string subtaskDescription = Console.ReadLine();

                var subtask = new { Title = subtaskTitle, Description = subtaskDescription };
                tasks.Add(subtask);

                Console.WriteLine("Підзавдання додано успішно!");
            }
            else
                Console.WriteLine("Невірний індекс завдання.");
        }

        static void EditTask(List<object> tasks)
        {
            Console.WriteLine("Введіть індекс завдання для редагування:");
            int taskIndex = int.Parse(Console.ReadLine());

            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                Console.WriteLine("Введіть нову назву завдання:");
                string newTitle = Console.ReadLine();
                Console.WriteLine("Введіть новий опис завдання:");
                string newDescription = Console.ReadLine();

                tasks[taskIndex] = newTitle;
                tasks[taskIndex] = newDescription;

                Console.WriteLine("Завдання відредаговано успішно!");
            }
            else
                Console.WriteLine("Невірний індекс завдання.");
        }

        static void DeleteTask(List<object> tasks)
        {
            Console.WriteLine("Введіть індекс завдання для видалення:");
            int taskIndex = int.Parse(Console.ReadLine());

            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                tasks.RemoveAt(taskIndex);
                Console.WriteLine("Завдання видалено успішно!");
            }
            else
                Console.WriteLine("Невірний індекс завдання.");
        }

        static void DisplayTasks(List<object> tasks)
        {
            Console.WriteLine("Список завдань:");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i}. Завдання: {tasks[i].GetType().GetProperty("Title").GetValue(tasks[i])}");
                Console.WriteLine($"   Опис: {tasks[i].GetType().GetProperty("Description").GetValue(tasks[i])}");

                var subtasks = (List<object>)tasks[i].GetType().GetProperty("Subtasks").GetValue(tasks[i]);
                if (subtasks.Count > 0)
                {
                    Console.WriteLine("   Підзавдання:");
                    for (int j = 0; j < subtasks.Count; j++)
                    {
                        Console.WriteLine($"   {j}. {subtasks[j].GetType().GetProperty("Title").GetValue(subtasks[j])}");
                        Console.WriteLine($"      Опис: {subtasks[j].GetType().GetProperty("Description").GetValue(subtasks[j])}");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
