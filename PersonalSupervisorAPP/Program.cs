using System;
using System.IO;

namespace PersonalSupervisorAPP
{
    class Program
    {
        string userName = null;
        string userPassword = null;
        static void Main(string[] args)
        {
            LogInMenu();
        }

        static void LogInMenu()
        {
            string userName = null;
            string userPassword = null;

            Console.WriteLine("=================");
            Console.WriteLine("Welcome to the Support App");
            Console.WriteLine("=================\n");
            Console.WriteLine("=================");
            Console.WriteLine("Log In");
            Console.WriteLine("=================\n");
            do
            {
                Console.Write("Please enter a user name: ");
                try
                {
                    userName = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry somthing went wrong");
                }


            } while (userName == "" || userName == null);

            do
            {
                Console.Write("\nPlease enter a password: ");
                try
                {
                    userPassword = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry somthing went wrong");
                }
                Console.ReadLine();
            } while (userPassword == "" || userPassword == null); 



        }

        
    }
}
