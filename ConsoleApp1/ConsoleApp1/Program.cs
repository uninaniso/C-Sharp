using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть перше число:");
        if (!int.TryParse(Console.ReadLine(), out int number1))
        {
            Console.WriteLine("Некоректний ввід. Будь ласка, введіть ціле число.");
            return;
        }

        Console.Write("Введіть друге число:");
        if (!int.TryParse(Console.ReadLine(), out int number2))
        {
            Console.WriteLine("Некоректний ввід. Будь ласка, введіть ціле число.");
            return;
        }

        if (number1 > number2)
        {
            int temp = number1;
            number1 = number2;
            number2 = temp;
        }

        Console.WriteLine($"Парні числа у діапазоні від {number1} до {number2}:");
        for (int i = number1; i < number2; i++)
            if (i % 2 == 0)
                Console.WriteLine(i);
    }
}