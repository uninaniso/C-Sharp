using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    namespace StudentInfo
    {
        internal sealed class Student
        {
            public readonly string firstName;
            public readonly string secondName;
            public readonly byte age;
            public readonly int cardID = new Random().Next(100, 999);
            public readonly bool AgeОver18;

            public Student(string firstName = "Alex", string secondName = "default", byte age = 18)
            {
                if (age > 100) age = 18;

                this.firstName = firstName;
                this.secondName = secondName;
                this.age = age;
                this.AgeОver18 = age >= 18;
            }
        }

        internal sealed class StudentGroup
        {
            private List<Student> Students;
            public readonly int Group = new Random().Next(1, 100);

            public void AddStudent(Student std)
            {
                if (std != null)
                    this.Students.Add(std);
            }

            public void RemoveStudent(int id)
            {
                if (id >= 0 && id < this.Students.Count)
                    this.Students.RemoveAt(id);
            }

            public void QuantityStudents()
            {
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("firstName " + this.Students[i].firstName);
                    Console.WriteLine("secondName " + this.Students[i].secondName);
                    Console.WriteLine("firstName " + this.Students[i].firstName);
                    Console.WriteLine("age " + this.Students[i].age);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("cardID " + this.Students[i].cardID);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------------------------------");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Operation completed!");
                Console.WriteLine("--------------\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            public StudentGroup() => Students = new List<Student>();
        }
    }
}
