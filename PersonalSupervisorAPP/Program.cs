using System;
using System.Collections.Generic;
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

        static void ReadCSVFile ()
        {
            List<string> CSVColunm1 = new List<string>();
            List<string> CSVColunm2 = new List<string>();
            List<string> CSVColunm3 = new List<string>();
            using (var reader = new StreamReader("userDetails.csv"))
            {
                
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine();   //Reads each line of file 
                        var values = line.Split(',');   //Splits the colums at the comma 


                        CSVColunm1.Add(values[0]);       //Adds the values of the 1st colum to the list 
                        CSVColunm2.Add(values[1]);          //Adds the values of the 2nd colum to the list
                        CSVColunm3.Add(values[2]);        //Adds the values of the 3rd colum to the list
                       
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("CSV File Unreadable");
                    }


                }
            }

        }


    }
}
