using System;
using System.Collections.Generic;
using System.IO;

namespace PersonalSupervisorAPP
{
    class Program
    {
        static List<string> personName = new List<string>();
        static List<string> storedUserName = new List<string>();
        static List<string> storedUserPassowrd = new List<string>();
        static List<string> jobPosition = new List<string>();
        static List<string> personalSupervisor = new List<string>();


        string userName = null;
        string userPassword = null;
        static void Main(string[] args)
        {
            ReadCSVFile();
           // LogInMenu();


        }

        static void LogInMenu()
        {
            string userName = null;
            string userPassword = null;
            int indexNumber = 0;
            bool validUsername = false;

            Console.WriteLine("=================");
            Console.WriteLine("Welcome to the Support App");
            Console.WriteLine("=================\n");
            Console.WriteLine("=================");
            Console.WriteLine("Log In");
            Console.WriteLine("=================\n");

            while (validUsername == false)
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

                foreach (string storedUserName in storedUserName)
                {

                    if (userName == storedUserName)
                    {
                        validUsername = true; 
                    }
                    else
                    {
                        indexNumber++;
                        validUsername = false; 
                    }
                }
            }
                


           

       


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

        static void ReadCSVFile()
        {

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("UserDetails.csv"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }



        }

            //using (var reader = new StreamReader("UserDetails.csv"))
            //{


               
            //    while (!reader.EndOfStream)
            //    {
            //        try
            //        {
            //            var line = reader.ReadLine();   //Reads each line of file 
            //            var values = line.Split(',', ',', ',', ',');   //Splits the colums at the comma 


            //            personName.Add(values[0]);       //Adds the persons name to the list  
            //            storedUserName.Add(values[1]);       //Adds the user name to the list
            //            storedUserPassowrd.Add(values[2]);       //Adds the user password to the list
            //            jobPosition.Add(values[3]);          //Adds the user job title to the list 
            //            if (values[4] != null)
            //            {
            //                personalSupervisor.Add(values[4]);  //Adds the students personal supervisor name
            //            }
            //            else
            //            {
            //                personalSupervisor.Add("");     //Adds a default value as member is alreay a PS or SL 
            //            }


            //        }
            //        catch (Exception)
            //        {
            //            Console.WriteLine("CSV File Unreadable");
            //        }


            //    }
            //}

        //}


    }
}
