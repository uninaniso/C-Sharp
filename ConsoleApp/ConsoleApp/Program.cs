using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    abstract class Contact
    {
        public abstract string Name { get; }
        public abstract string PhoneNumber { get; }
    }

    class PersonalContact : Contact
    {
        public override string Name { get; }
        public override string PhoneNumber { get; }

        public PersonalContact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    class BusinessContact : Contact
    {
        public override string Name { get; }
        public override string PhoneNumber { get; }

        public BusinessContact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void DisplayContacts()
        {
            Console.WriteLine("Список контактів:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Ім'я: {contact.Name}, Номер телефону: {contact.PhoneNumber}");
            }
        }

        public Contact FindContactByName(string name)
        {
            return contacts.Find(contact => contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public bool RemoveContact(string name)
        {
            Contact contactToRemove = FindContactByName(name);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();

            contactManager.AddContact(new PersonalContact("Іван", "123-456-789"));
            contactManager.AddContact(new BusinessContact("Компанія 1", "987-654-321"));
            contactManager.AddContact(new PersonalContact("Марія", "111-222-333"));

            contactManager.DisplayContacts();

            string nameToFind = "Марія";
            Contact foundContact = contactManager.FindContactByName(nameToFind);
            if (foundContact != null)
            {
                Console.WriteLine($"\nКонтакт з ім'ям '{nameToFind}' знайдений:");
                Console.WriteLine($"Ім'я: {foundContact.Name}, Номер телефону: {foundContact.PhoneNumber}");
            }
            else
            {
                Console.WriteLine($"\nКонтакт з ім'ям '{nameToFind}' не знайдений.");
            }

            string nameToRemove = "Компанія 1";
            bool removed = contactManager.RemoveContact(nameToRemove);
            if (removed)
            {
                Console.WriteLine($"\nКонтакт з ім'ям '{nameToRemove}' був успішно видалений.");
            }
            else
            {
                Console.WriteLine($"\nКонтакт з ім'ям '{nameToRemove}' не був знайдений для видалення.");
            }

            contactManager.DisplayContacts();
        }
    }
}