using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface IAnimal
    {
        event EventHandler<string> HealthChanged;
        string Name { get; }
        void Voice();
        void Eat();
        void Heal();
        void SetEnclosure(Enclosure enclosure);
    }

    abstract class Mammal : IAnimal
    {
        public event EventHandler<string> HealthChanged;
        public string Name { get; protected set; }
        public string DietType { get; set; }
        public string HealthStatus { get; set; }
        public Enclosure Enclosure { get; private set; }

        public abstract void Voice();
        public abstract void Eat();
        public void Heal()
        {
            HealthStatus = "Healthy";
            HealthChanged?.Invoke(this, $"{Name} is now healthy.");
        }

        public void SetEnclosure(Enclosure enclosure)
        {
            Enclosure = enclosure;
        }
    }

    class Enclosure
    {
        public string Name { get; }
        private List<IAnimal> animals = new List<IAnimal>();

        public Enclosure(string name)
        {
            Name = name;
        }

        public void AddAnimal(IAnimal animal)
        {
            animals.Add(animal);
            animal.HealthChanged += AnimalHealthChanged;
            animal.SetEnclosure(this);
        }

        public List<IAnimal> GetAnimals()
        {
            return animals;
        }

        public void DisplayAnimals()
        {
            Console.WriteLine($"Тварини у вольєрі {Name}:");
            foreach (var animal in animals)
            {
                Console.Write($"{animal.Name}");
                if (animal is Mammal mammal)
                {
                    Console.WriteLine($" - Здоров'я: {mammal.HealthStatus}");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        private void AnimalHealthChanged(object sender, string message)
        {
            Console.WriteLine($"Повідомлення з вольєри {Name}: {message}");
        }
    }

    class Dog : Mammal
    {
        public Dog(string name)
        {
            Name = name;
        }

        public override void Voice()
        {
            Console.WriteLine("Гав-гав!");
        }

        public override void Eat()
        {
            Console.WriteLine("Собака їсть кістки.");
        }
    }

    class Cat : Mammal
    {
        public Cat(string name)
        {
            Name = name;
        }

        public override void Voice()
        {
            Console.WriteLine("Мяу!");
        }

        public override void Eat()
        {
            Console.WriteLine("Кіт їсть рибу.");
        }
    }

    class Elephant : Mammal
    {
        public Elephant(string name)
        {
            Name = name;
        }

        public override void Voice()
        {
            Console.WriteLine("Уф-уф!");
        }

        public override void Eat()
        {
            Console.WriteLine("Слон їсть траву.");
        }
    }

    class Zoo
    {
        private List<Enclosure> enclosures = new List<Enclosure>();

        public void AddEnclosure(Enclosure enclosure)
        {
            enclosures.Add(enclosure);
        }

        public void DisplayEnclosures()
        {
            Console.WriteLine("Вольєри у зоопарку:");
            foreach (var enclosure in enclosures)
            {
                Console.WriteLine(enclosure.Name);
            }
        }

        public void FeedAnimals()
        {
            foreach (var enclosure in enclosures)
            {
                foreach (var animal in enclosure.GetAnimals())
                {
                    animal.Eat();
                }
            }
        }

        public void HealAnimals()
        {
            foreach (var enclosure in enclosures)
            {
                foreach (var animal in enclosure.GetAnimals())
                {
                    animal.Heal();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            Enclosure dogEnclosure = new Enclosure("Для собак");
            dogEnclosure.AddAnimal(new Dog("Рекс"));
            dogEnclosure.AddAnimal(new Dog("Барон"));
            zoo.AddEnclosure(dogEnclosure);

            Enclosure catEnclosure = new Enclosure("Для котів");
            catEnclosure.AddAnimal(new Cat("Мурка"));
            catEnclosure.AddAnimal(new Cat("Том"));
            zoo.AddEnclosure(catEnclosure);

            Enclosure elephantEnclosure = new Enclosure("Для слонів");
            elephantEnclosure.AddAnimal(new Elephant("Думбо"));
            zoo.AddEnclosure(elephantEnclosure);

            zoo.DisplayEnclosures();
            zoo.FeedAnimals();
            zoo.HealAnimals();
        }
    }
}