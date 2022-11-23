using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonalSupervisorAPP
{
    class PersonalSupervisor
    {
        private static string _supervisorName;
        private static string _supervisorUserName;
        private static string _supervisorUserPassword;
        private static string _jobtype;

        static List<string> dateSubmitted = new List<string>();
        static List<string> studentName = new List<string>();
        static List<string> supervisorName = new List<string>();
        static List<string> studentFeeling = new List<string>();

        public PersonalSupervisor(string name, string userName, string userPassword)
        {
            _supervisorName = name;
            _supervisorUserName = userName;
            _supervisorUserPassword = userPassword;
            _jobtype = "ps";


        }
        //Displays the menu that the student can see 
        public static void PersonalSupervisorMenu()
        {
            Console.Clear();
            int userMenuChoice = 0;
            Console.WriteLine("=================");
            Console.WriteLine("Personal Supervisor Menu");
            Console.WriteLine("=================\n");
            Console.WriteLine("=================");
            Console.WriteLine("1. Veiw students feelings");
            Console.WriteLine("2. View upcoming meetings");
            while (userMenuChoice < 1 || userMenuChoice >2) 
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

            } 

            switch (userMenuChoice)
            {
                case 1:
                    StudentFeelings();
                    break;
                case 2:
                    ViewMeetings();
                    break;
               

            }


            static void ViewMeetings()
            {
                try
                {
                    int index = 0;
                    bool noMeetings = true;
                    foreach (string meeting in Program.meetingsBooked)
                    {
                        if (Program.meetingSupervisor[index] == PersonalSupervisor._supervisorName && Program.meetingsBooked[index] != "")
                        {
                            Console.WriteLine(Program.meetingDay[index] + " at " + Program.meetingTime[index] + " with " + Program.meetingsBooked[index]);
                          
                            noMeetings = false;
                        }
                        index++;
                    }

                }
                catch (Exception)
                {

                    Console.WriteLine("An error has occored");

                }
            
                Program.LogOutOrContine(PersonalSupervisor._jobtype);



            }

            static void StudentFeelings()
            {
                string sName = PersonalSupervisor._supervisorName; 
                List<string> supervsiorStudentFeelings = new List<string>();
                string filePath = "studentFeeling.csv"; //File that needs to be read
                //Console.WriteLine(File.Exists(filePath) ? "File exists." : "File does not exist.");

                //Reads the file and sperates the inforamtion to be used later 
                using (var reader = new StreamReader(filePath))
                {

                    while (!reader.EndOfStream)
                    {
                        try
                        {
                            var line = reader.ReadLine();   //Reads each line of file 
                            var values = line.Split(',', ',', ',');   //Splits the colums at the comma 


                            dateSubmitted.Add(values[0]);
                            studentName.Add(values[1]);
                            studentFeeling.Add(values[2]);
                            supervisorName.Add(values[3]);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error occored loading student status please try again");
                        }


                    }
                }

                for (int i = 0; i < dateSubmitted.Count; i++)
                {
                    if (supervisorName[i] == sName)
                    {
                        Console.WriteLine("Date Submitted: " + dateSubmitted[i]);
                        Console.WriteLine("Student Name: " + studentName[i]);
                        Console.WriteLine("Feeling Submitted: " + studentFeeling[i]);
                        Console.WriteLine("-------------------------------------------\n");
                        
                    }
                }

             

                Program.LogOutOrContine(PersonalSupervisor._jobtype);

            }

            


        }

    }
}
