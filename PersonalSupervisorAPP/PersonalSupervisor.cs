using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalSupervisorAPP
{
    class PersonalSupervisor
    {
        private string _supervisorName;
        private string _supervisorUserName;
        private string _supervisorUserPassword;

        public PersonalSupervisor(string name, string userName, string userPassword)
        {
            _supervisorName = name;
            _supervisorUserName = userName;
            _supervisorUserPassword = userPassword;
          

        }
        //Displays the menu that the student can see 
        public static void PersonalSupervisorMenu()
        {
            int userMenuChoice = 0;
            Console.WriteLine("=================");
            Console.WriteLine("Personal Supervisor Menu");
            Console.WriteLine("=================\n");
            Console.WriteLine("=================");
            Console.WriteLine("1. Veiw students feelings");
            Console.WriteLine("2. View upcoming meetings");
            Console.WriteLine("3. View students status");
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
