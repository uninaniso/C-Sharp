using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using ConsoleApp.StudentInfo;

namespace ConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentGroup students = new StudentGroup();

            students.AddStudent(new Student(GetNewName(), GetNewName(), (byte)new Random().Next(1, 100)));
            Thread.Sleep(10);
            students.AddStudent(new Student(GetNewName(), GetNewName(), (byte)new Random().Next(1, 100)));
            Thread.Sleep(10);
            students.AddStudent(new Student(GetNewName(), GetNewName(), (byte)new Random().Next(1, 100)));
            Thread.Sleep(10);
            students.AddStudent(new Student(GetNewName(), GetNewName(), (byte)new Random().Next(1, 100)));
            Thread.Sleep(10);
            students.AddStudent(new Student(GetNewName(), GetNewName(), (byte)new Random().Next(1, 100)));

            students.AddStudent(new Student());
            students.QuantityStudents();
            students.RemoveStudent(5);
            students.QuantityStudents();

            Console.ReadKey();
        }

        static string GetNewName()
        {
            string name = "";
            string letter = "qwertyuiopasdfghjklzxcvbnm";
            Thread.Sleep(10);
            int length = new Random().Next(1, 20);

            for (int i = 0; i < length; i++)
                name += letter[new Random().Next(0, 25)];

            return name;
        }
    }
}
