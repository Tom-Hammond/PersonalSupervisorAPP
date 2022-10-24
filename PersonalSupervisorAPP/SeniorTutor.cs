using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PersonalSupervisorAPP
{
    class SeniorTutor
    {
        private string _tutorName;
        private string _tutorUserName;
        private string _tutorUserPassword;
        private static string _jobtype;

        static List<string> dateSubmitted = new List<string>();
        static List<string> studentName = new List<string>();
        static List<string> supervisorName = new List<string>();
        static List<string> studentFeeling = new List<string>();

        public SeniorTutor(string name, string userName, string userPassword)
        {
            _tutorName = name;
            _tutorUserName = userName;
            _tutorUserPassword = userPassword;
            _jobtype = "st";

        }

        //Displays the menu that the student can see 
        public static void SeniorTutorMenu()
        {
            int userMenuChoice = 0;
            Console.WriteLine("=================");
            Console.WriteLine("Senior Tutor Menu");
            Console.WriteLine("=================\n");
            Console.WriteLine("1. View all student status");
            Console.WriteLine("2. Add student to database");

            while (userMenuChoice == 0)
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
                    StudentStatus();
                    break;
                case 2:
                    AddUserToSystem();
                    break;
               

            }

        }

        static void StudentStatus()
        {
            
            List<string> supervsiorStudentFeelings = new List<string>();
            string filePath = @"C:\Users\tomha\source\repos\PersonalSupervisorAPP\PersonalSupervisorAPP\studentFeelings.csv"; //File that needs to be read
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
               
                    supervsiorStudentFeelings.Add(dateSubmitted[i] + studentName[i] + studentFeeling[i] + supervisorName[i]);
                
            }

            foreach (string studentRecord in supervsiorStudentFeelings)
            {
                Console.WriteLine(studentRecord);
            }

        }

        static void AddUserToSystem()
        {
            string userName = null;
            string userLogIn= null;
            string userPassword = null;
            string jobType = null;
            string personalSupervisor = null;
            int userChoice = 0;
            string dataToBeAdded = null;

            Console.Clear();
            Console.WriteLine("==============");
            Console.WriteLine("Add user to system"); 
            Console.WriteLine("==============\n");

            while (jobType == null)
            {
                Console.WriteLine("What job role would you like to add (Student or PS)");
                jobType = Console.ReadLine();
                if (jobType == "student" || jobType == "Student")
                {
                    jobType = "student";  
                }
                else if (jobType == "ps" || jobType == "PS" || jobType == "Personal Supervisor" || jobType == "Perosnal superviror" || jobType == "perosnal superviror")
                {
                    jobType = "ps";
                }
                else
                {
                    jobType = null;
                }
         
            }

            if (jobType == "student")
            {
                try
                {
                    Console.Write("Please enter the persons name: ");
                    userName = Console.ReadLine();
                    Console.Write("Please enter a username for the login: ");
                    userLogIn = Console.ReadLine();
                    Console.Write("Please enter a password for the login: ");
                    userPassword = Console.ReadLine();
                    jobType = "student";
                    while (userChoice == 0)
                    {
                        Console.WriteLine("Enter persoanl supervisor name");
                        Console.WriteLine("1. Kate Moss");
                        Console.WriteLine("2. Bob Young");
                        userChoice = int.Parse(Console.ReadLine());
                        if (userChoice == 1)
                        {
                            personalSupervisor = "Kate Moss";
                        }
                        else if (userChoice == 2)
                        {
                            personalSupervisor = "Bob Young";
                        }
                        else
                        {
                            userChoice = 0; 
                        }
                    }

                    dataToBeAdded = userName + "," + userLogIn + "," + userPassword + "," + jobType + "," + personalSupervisor;

                    Program.LogOutOrContine(SeniorTutor._jobtype);


                }
                catch (Exception)
                {
                    Console.WriteLine("A error occored");
                    Program.LogOutOrContine(SeniorTutor._jobtype);
                }
            

            }
            else if (jobType == "ps")
            {
                try
                {
                    Console.Write("Please enter the persons name: ");
                    userName = Console.ReadLine();
                    Console.Write("Please enter a username for the login: ");
                    userLogIn = Console.ReadLine();
                    Console.Write("Please enter a password for the login: ");
                    userPassword = Console.ReadLine();
                    jobType = "ps";
                    personalSupervisor = ""; 
                   

                    dataToBeAdded = userName + "," + userLogIn + "," + userPassword + "," + jobType + "," + personalSupervisor;

                    Program.LogOutOrContine(SeniorTutor._jobtype);


                }
                catch (Exception)
                {
                    Console.WriteLine("A error occored");
                    Program.LogOutOrContine(SeniorTutor._jobtype);
                }

            }

            using (StreamWriter writer = File.AppendText("muserDetails.csv"))
            {
                writer.WriteLine(dataToBeAdded);
            }



        }







    }

   
}
