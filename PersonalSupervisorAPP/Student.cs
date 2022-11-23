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
        public static string _studentPersonalSupervisor;
        private static string _jobtype;
        private static int _feelingsEntered = 0;
        private static int _meetingsBooked = 0;

        static List<string> studentName = new List<string>();


        //Constructor 
        public Student(string name, string userName, string userPassword, string personalSupervisor) 
        {
            _studentName = name;
            _studentUserName = userName;
            _studentUserPassword = userPassword;
            _studentPersonalSupervisor = personalSupervisor;
           _jobtype = "student";
            _feelingsEntered = 0; 

        }

        public int FeelingsRegistered
        {
            get { return _feelingsEntered; }          
        }
        public int MeetingsBooked   
        {
            get { return _meetingsBooked; }          
        }
        public string StudentName
        {
            get { return _studentName; }
        }
        public string PersonalSupervisorName
        {
            get { return _studentPersonalSupervisor; }
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
            Console.Clear(); 

            string filePath = @"studentFeeling.csv";
            
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();   //Reads each line of file 
                    var values = line.Split(',', ',', ',');   //Splits the colums at the comma
                    studentName.Add(values[1]);

                   
                }
            }

            for (int i = 0; i < studentName.Count; i++)
            {
                if (studentName[i] == Student._studentName)
                {
                    _feelingsEntered++;
                }
            }



            if (Student._feelingsEntered < 3)
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

               // string filePath = @"studentFeeling.csv";
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(DateTime.Now + "," + Student._studentName + "," + Student._studentPersonalSupervisor + "," + studentFeeling);
                    Console.WriteLine("Feeling Added");
                }

               

             
                Student._feelingsEntered++;

             

            }
            else
            {
                Console.WriteLine("\nYou have alreay submitted the maximum amount of feelings");
                Console.WriteLine("If you have any more issues please contact your personal supervisor");
                Console.WriteLine("Your personal supervsior is " + Student._studentPersonalSupervisor);
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

            int otherPsCount = 0;
            if (_studentPersonalSupervisor == "Kate Moss")
            {
                lineToEdit = userChoice;
            }
            else if (_studentPersonalSupervisor == "Bob Young")
            {
                foreach (string supervisor in Program.meetingSupervisor)
                {
                    if (supervisor != _studentPersonalSupervisor)
                    {
                        otherPsCount++;
                    }
                }
                lineToEdit =  otherPsCount + userChoice + 1; 
            }

            string meetingBookedLine = Program.meetingDay[lineToEdit] + Program.meetingTime[lineToEdit] + Program.meetingSupervisor[lineToEdit] + Student._studentName;

            Program.lineChanger(meetingBookedLine, "meetings.csv", lineToEdit);

            
            Console.WriteLine("Your meeting has been booked");
            Console.WriteLine(Program.meetingDay[lineToEdit] + " at " + Program.meetingTime[lineToEdit] + " with " + Program.meetingSupervisor[lineToEdit]);
            _meetingsBooked++;

            Program.LogOutOrContine(Student._jobtype);



        }

        static void ViewMeetings()
        {
            bool bookMeeting = false;
            
            Program.GetMeetingTimes(); 

            for (int i = 0; i < Program.meetingsBooked.Count; i++)
            {
                   if (Program.meetingsBooked[i] == Student._studentName)
                   {

                        if (Program.meetingTime[i] < 12 && Program.meetingTime[i] >= 9)
                        {
                            Console.WriteLine("Day: " + Program.meetingDay[i] + " ");
                            Console.WriteLine("Time: " + Program.meetingTime[i] + "am" + " ");
                            Console.WriteLine("Supervisor Name: " + Program.meetingSupervisor[i] + " ");
                            Console.WriteLine("-------------------------------------------\n");
                        }

                        else
                        {
                            Console.WriteLine("Day: " + Program.meetingDay[i] + " ");
                            Console.WriteLine("Time: " + Program.meetingTime[i] + "pm" + " ");
                            Console.WriteLine("Supervisor Name: " + Program.meetingSupervisor[i] + " ");
                            Console.WriteLine("-------------------------------------------\n");
                        }
                          
                        bookMeeting = true; 
                   }
                   
            }

            if (bookMeeting == false)
            {
                Console.WriteLine("No meetings booked");
            }
 
            Program.LogOutOrContine(Student._jobtype);





        }


        


    }
}
