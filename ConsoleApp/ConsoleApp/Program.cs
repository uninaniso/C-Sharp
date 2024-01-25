using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Student
    {
        public readonly string firstname;
        public readonly byte age;
        public readonly bool AgeОver18;

        public Student(string firstname = "Alex", byte age = 18)
        {
            if (age > 100) age = 18;

            this.firstname = firstname;
            this.age = age;
            this.AgeОver18 = age >= 18;
        }

        Student() { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];

            for (byte b = 0;b < 5; b++)
            {
                Console.WriteLine("input firstname ");
                string firtsname = Console.ReadLine();
                Console.WriteLine("input age ");
                byte age = Convert.ToByte(Console.ReadLine());

                students[b] = new Student(firtsname, age);
            }

            for (byte b = 0; b < 5; b++)
                if (students[b].AgeОver18)
                {
                    Console.WriteLine("firtsname " + students[b].firstname);
                    Console.WriteLine("age " + students[b].age);
                }
        }
    }
}
