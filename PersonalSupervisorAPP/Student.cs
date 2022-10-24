using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.IO; 

namespace PersonalSupervisorAPP
{
    public class Student
    {
        private static string _studentName;
        private static string _studentUserName;
        private static string _studentUserPassword;
        private static string _studentPersonalSupervisor;
        private static string _jobtype;
       // static string[] studentFeelings = new string[3];
        static int timesEntered = 0;
        static Timer feelingsTimer; 

        //Constructor 
        public Student(string name, string userName, string userPassword, string personalSupervisor) 
        {
            _studentName = name;
            _studentUserName = userName;
            _studentUserPassword = userPassword;
            _studentPersonalSupervisor = personalSupervisor;
           _jobtype = "student"; 

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
                    else
                    {
                        confirmedFeeling = false;
                    }

                } while (confirmedFeeling == false);

                string filePath = @"studentFeelings.csv"; 

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(DateTime.Now + "," + Student._studentName + "," + Student._studentPersonalSupervisor + "," + studentFeeling);
                    Console.WriteLine("Feeling Added");
                }

             
                timesEntered++;

             

            }

            Program.LogOutOrContine(_jobtype);
                   

        }

        static void BookMeeting()
        {
            int index = 0;
            int displayNum = 1;
            int lineToEdit = 0;
            int userChoice = 0; 
            List<string> meetingsAvaliable = new List<string>();

            Console.WriteLine("===============");
            Console.WriteLine("Book a meeting"); 
            Console.WriteLine("===============\n");

            Console.WriteLine("Your personal supervisor is " + Student._studentPersonalSupervisor);

            Program.GetMeetingTimes();

            foreach (string avaliableMeeting in Program.meetingsBooked)
            {
                
                if (avaliableMeeting == "")
                {
                    if (Program.meetingSupervisor[index] == Student._studentPersonalSupervisor)
                    {
                        Console.WriteLine(displayNum + ". "  + Program.meetingDay[index] + ", " +  Program.meetingTime[index] + ", " + Program.meetingSupervisor[index] + ", " + "Avaliable");
                        displayNum++;
                    }
                }
                index++;
                
            }
            displayNum = displayNum -  1; 


            

            while (userChoice == 0)
            {
                Console.WriteLine("\nPlease choose a meeting you would like to book(1 - " + displayNum + ")");
                try
                {
                    userChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    userChoice = 0;
                    
                }
               
            }
            

            if (Student._studentPersonalSupervisor == "Kate Moss")
            {
                lineToEdit = userChoice - 1;
            }
            else if (Student._studentPersonalSupervisor == "Bob Young")
            {
                lineToEdit = index - userChoice - 1; 
            }

            string meetingBookedLine = Program.meetingDay[lineToEdit] + Program.meetingTime[lineToEdit] + Program.meetingSupervisor[lineToEdit] + Student._studentName;

            Program.lineChanger(meetingBookedLine, "meetings.csv", lineToEdit);

            Console.WriteLine("Your meeting has been booked");
            Console.WriteLine(meetingBookedLine);

            Program.LogOutOrContine(Student._jobtype);



        }

        static void ViewMeetings()
        {
           
             for (int i = 0; i < Program.meetingsBooked.Count; i++)
             {
                   if (Program.meetingsBooked[i] == Student._studentName)
                   {
                            Console.WriteLine(Program.meetingDay[i] + Program.meetingTime[i] + Program.meetingSupervisor[i] + Program.meetingsBooked[i]);
                            Program.LogOutOrContine(Student._jobtype);
                   }
             } 
                
           
            Console.WriteLine("No upcoming meetings");
            Program.LogOutOrContine(Student._jobtype);





        }


        


    }
}
