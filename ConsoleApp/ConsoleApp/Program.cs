using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class NoSupportLogging : Exception
    {
        public NoSupportLogging() : base() { }
    }

    abstract class Log
    {
        public static string log_History = "";
        public static void Logging() { throw new NoSupportLogging(); }
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAuthorized { get; set; }
    }

    delegate void AuthorizationHandler(User user);

    class AuthorizationSystem : Log
    {
        public new static string log_History = "";

        private List<User> users = new List<User>();

        public event AuthorizationHandler UserAuthorized;

        public static void Logging(string Event, bool Is_Error = false, bool Fatal_Error = false)
        {
            log_History += $"[{DateTime.UtcNow}] {Event} {(Is_Error ? (Fatal_Error ? "Error" : "Fatal Error") : "Info")}\n";
        }

        public void AddUser(User user)
        {
            try
            {
                users.Add(user);
                Logging($"user {user} was add");
            }

            finally
            {
                Logging($"drying add user {user}", true);
            }
        }

        public void RemoveUser(User user)
        {
            try
            {
                users.Remove(user);
                Logging($"user {user} was deleted");
            }

            finally
            {
                Logging($"drying deleted user {user}", true);
            }
        }

        public void BlockUser(User user)
        {
            user.IsAuthorized = false;
            Console.WriteLine($"Користувач {user.Username} заблокований.");
            Logging($"Користувач {user.Username} заблокований");
        }

        protected virtual void OnUserAuthorized(User user)
        {
            UserAuthorized?.Invoke(user);
        }

        public static void DisplayAuthorizationStatus(User user)
        {
            if (user.IsAuthorized)
            {
                Console.WriteLine($"Користувач {user.Username} авторизований.");
                Logging($"user {user.Username} is Authorized");
            }
            else
            {
                Console.WriteLine($"Користувач {user.Username} не авторизований.");
                Logging($"Користувач {user.Username} не авторизований.");
            }
        }

        public static void BlockUserOnFailedAuthorization(User user)
        {
            Console.WriteLine($"Невдала спроба авторизації для користувача {user.Username}. Заблоковано.");
            Logging($"Невдала спроба авторизації для користувача {user.Username}. Заблоковано.");
        }

        public void AuthorizeUser(string username, string password)
        {
            User user = users.Find(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                user.IsAuthorized = true;
                Console.WriteLine($"Користувач {user.Username} успішно авторизований.");
                OnUserAuthorized(user);
            }
            else
            {
                Console.WriteLine($"Невірне ім'я користувача або пароль.");
                BlockUserOnFailedAuthorization(new User { Username = username });
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AuthorizationSystem authorizationSystem = new AuthorizationSystem();
            AuthorizationHandler authorizationHandler = AuthorizationSystem.DisplayAuthorizationStatus;

            authorizationSystem.AddUser(new User { Username = "user1", Password = "pass1" });
            authorizationSystem.AddUser(new User { Username = "user2", Password = "pass2" });

            authorizationSystem.UserAuthorized += authorizationHandler;

            authorizationSystem.AuthorizeUser("user1", "pass1");
            authorizationSystem.AuthorizeUser("user2", "wrongpass");

            User userToRemove = new User { Username = "user1", Password = "pass1" };
            authorizationSystem.RemoveUser(userToRemove);
            authorizationSystem.RemoveUser(new User { Username = "nonexistentuser", Password = "pass" });

            authorizationSystem.BlockUser(new User { Username = "user2", Password = "pass2" });

            Console.WriteLine(AuthorizationSystem.log_History);
        }
    }
}
