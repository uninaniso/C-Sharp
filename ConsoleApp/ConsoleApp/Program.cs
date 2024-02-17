using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface ITransport
    {
        void Move();
        void Stop();
        string GetInfo();
    }

    public class Car : ITransport
    {
        public void Move() { Console.WriteLine("Автомобиль едет по дороге."); }

        public void Stop() { Console.WriteLine("Автомобиль остановился."); }

        public string GetInfo() => "Это автомобиль.";
    }

    public class Bicycle : ITransport
    {
        public void Move() { Console.WriteLine("Велосипед движется по дороге."); }

        public void Stop() { Console.WriteLine("Велосипед остановился."); }

        public string GetInfo() => "Это велосипед.";
    }

    public class Airplane : ITransport
    {
        public void Move() { Console.WriteLine("Самолет летит в небе."); }

        public void Stop() { Console.WriteLine("Самолет приземлился."); }

        public string GetInfo() => "Это самолет.";
    }

    public class Boat : ITransport
    {
        public void Move() { Console.WriteLine("Катер плывет по воде."); }

        public void Stop() { Console.WriteLine("Катер остановился."); }

        public string GetInfo() => "Это катер.";
    }

    public class Scooter : ITransport
    {
        public void Move() { Console.WriteLine("Скутер едет по тротуару."); }

        public void Stop() { Console.WriteLine("Скутер остановился."); }

        public string GetInfo() => "Это скутер.";
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITransport[] transport = {
            new Car(),
            new Bicycle(),
            new Airplane(),
            new Boat(),
            new Scooter()
            };

            foreach (ITransport transportItem in transport)
            {
                Console.WriteLine(transportItem.GetInfo());
                transportItem.Move();
                transportItem.Stop();
                Console.WriteLine();
            }
        }
    }
}