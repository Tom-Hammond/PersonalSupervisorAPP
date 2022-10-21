using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalSupervisorAPP
{
    class SeniorTutor
    {
        private string _tutorName;
        private string _tutorUserName;
        private string _tutorUserPassword;

        public SeniorTutor(string name, string userName, string userPassword)
        {
            _tutorName = name;
            _tutorUserName = userName;
            _tutorUserPassword = userPassword;


        }

        //Displays the menu that the student can see 
        public static void SeniorTutorMenu()
        {
            int userMenuChoice = 0;
            Console.WriteLine("=================");
            Console.WriteLine("Student Menu");
            Console.WriteLine("=================\n");
            Console.WriteLine("=================");
            Console.WriteLine("1. View all student status");
            Console.WriteLine("2. Add student to database");

            do
            {
                Console.WriteLine("\nPlease enter a option from 1 to 2");

                try
                {
                    userMenuChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("That wasen't a number");
                }

            } while (userMenuChoice != 1 || userMenuChoice != 2 );

            switch (userMenuChoice)
            {
                case 1:
                    // add method here 
                    break;
                case 2:
                    // add method here 
                    break;
               

            }







        }







    }

   
}
