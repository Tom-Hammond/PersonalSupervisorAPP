using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalSupervisorAPP
{
    public class Student
    {
        //Displays the menu that the student can see 
        public static void StudentMenu()
        {
            int userMenuChoice = 0;
            Console.WriteLine("=================");
            Console.WriteLine("Student Menu");
            Console.WriteLine("=================\n");
            Console.WriteLine("=================");
            Console.WriteLine("1. Report feelings");
            Console.WriteLine("2. Book a meeting");
            Console.WriteLine("3. View meetings");
            do
            {
                Console.WriteLine("\nPlease enter a option from 1 to 3");

                try
                {
                    userMenuChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("That wasen't a number");
                }

            } while (userMenuChoice != 1 || userMenuChoice != 2 || userMenuChoice != 3);

            switch (userMenuChoice)
            {
                case 1:
                    // add method here 
                    break;
                case 2:
                    // add method here 
                    break;
                case 3:
                    // add method here 
                    break;

            }







        }
    }
}
