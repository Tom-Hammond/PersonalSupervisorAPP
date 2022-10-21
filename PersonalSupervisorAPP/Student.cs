using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace PersonalSupervisorAPP
{
    public class Student
    {
        private string _studentName;
        private string _studentUserName;
        private string _studentUserPassword;
        private string _studentPersonalSupervisor;
        static string[] studentFeelings = new string[3];
        static int timesEntered = 0;
        static Timer feelingsTimer; 

        //Constructor 
        public Student(string name, string userName, string userPassword, string personalSupervisor) 
        {
            _studentName = name;
            _studentUserName = userName;
            _studentUserPassword = userPassword;
            _studentPersonalSupervisor = personalSupervisor;

        }
        //Displays the menu that the student can see 
        public static void StudentMenu()
        {
            Console.Clear();

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

            } while (userMenuChoice <=0 || userMenuChoice >=4);

            switch (userMenuChoice)
            {
                case 1:
                    ReportFeelings();
                    break;
                case 2:
                    BookMeeting();
                    break;
                case 3:
                    ViewMeetings();
                    break;

            }







        }

        static void ReportFeelings()
        {


            if (timesEntered < 3)
            {
                Console.Clear();
                string studentFeeling = null;
                bool confirmedFeeling = false;
                string yesOrNo = null;
                do
                {
                    Console.WriteLine("===================");
                    Console.WriteLine("Report how your feeling");
                    Console.WriteLine("===================\n");
                    Console.WriteLine("Hi there, How do you feel like your doing this current semester?");
                    Console.WriteLine("Pleaase describ how you are feeling and how you ahve been getting on with Uni");
                    studentFeeling = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("\nPlease confirm this is what you would like to submit (Y or N)");
                    Console.WriteLine(studentFeeling + "\n");
                    yesOrNo = Console.ReadLine();
                    if (yesOrNo == "Y" || yesOrNo == "y")
                    {
                        confirmedFeeling = true;
                    }

                } while (confirmedFeeling = false);

                studentFeelings[timesEntered] = studentFeeling;
                timesEntered++;

            }

            Program.LogOutOrContine();
                   

        }

        static void BookMeeting()
        {


        }

        static void ViewMeetings()
        {


        }


        


    }
}
