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
            CreateMembers();
            LogInMenu();


        }

        static void LogInMenu()
        {
            string userName = null;
            string userPassword = null;
            string userType = null;
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
                indexNumber = 0;
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
                        break; 
                    }
                    else
                    {
                        indexNumber++;
                        validUsername = false; 
                    }
                }
            }


            if (validUsername == true)
            {
                userType = jobPosition[indexNumber];
                do
                {
                    Console.Write("\nPlease enter a password: ");
                    try
                    {
                        userPassword = Console.ReadLine();
                        if (userPassword == storedUserPassowrd[indexNumber])
                        {
                           
                            if (userType == "Student")
                            {
                                Student.StudentMenu();
                            }
                            else if (userType == "PS")
                            {
                                PersonalSupervisor.PersonalSupervisorMenu();
                            }
                            else if (userType == "ST")
                            {
                                SeniorTutor.SeniorTutorMenu();
                            }

                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Sorry somthing went wrong");
                    }
                    Console.ReadLine();
                } while (userPassword == "" || userPassword == null);
            }
            


           



        }

        static void ReadCSVFile()
        {
            string filePath = @"UserDetails.csv"; //File that needs to be read
        //    Console.WriteLine(File.Exists(filePath) ? "File exists." : "File does not exist.");
            
            //Reads the file and sperates the inforamtion to be used later 
            using (var reader = new StreamReader(filePath))
            {


               
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine();   //Reads each line of file 
                         var values = line.Split(',', ',', ',', ',');   //Splits the colums at the comma 


                        personName.Add(values[0]);       //Adds the persons name to the list  
                        storedUserName.Add(values[1]);       //Adds the user name to the list
                        storedUserPassowrd.Add(values[2]);       //Adds the user password to the list
                        jobPosition.Add(values[3]);          //Adds the user job title to the list 
                        if (values[4] != null)
                        {
                            personalSupervisor.Add(values[4]);  //Adds the students personal supervisor name
                        }
                        else
                        {
                         personalSupervisor.Add("");     //Adds a default value as member is alreay a PS or SL 
                        }


                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error occored loading students please try again");
                    }


                }
            }

        }

        static void CreateMembers()
        {
            int indexNum = 0;
            List<Student> studentsList = new List<Student>();
            List <PersonalSupervisor> personakSupervisorList = new List<PersonalSupervisor>();
            List <SeniorTutor> seniorTutorList = new List<SeniorTutor>();

            foreach (string job in jobPosition)
            {
                if (job == "Student")
                {
                    studentsList.Add(new Student(personName[indexNum], storedUserName[indexNum], storedUserPassowrd[indexNum], personalSupervisor[indexNum]));
                    indexNum++;
                }
                else if (job == "PS")
                {
                    personakSupervisorList.Add(new PersonalSupervisor(personName[indexNum], storedUserName[indexNum], storedUserPassowrd[indexNum]));
                    indexNum++; 
                }
                else if (job == "SL")
                {
                    seniorTutorList.Add(new SeniorTutor(personName[indexNum], storedUserName[indexNum], storedUserPassowrd[indexNum]));
                    indexNum++;
                }
                else
                {
                    indexNum++;
                }
            }       

        }

        public static void LogOutOrContine()
        {
            int userChoice = 0;

            Console.WriteLine("\n========================");
            Console.WriteLine("1. Main menu");
            Console.WriteLine("2. Log out\n");


            try
            {
                do
                {
                    Console.WriteLine("Please enter a value between 1 and 2");
                    userChoice = int.Parse(Console.ReadLine());
                } while (userChoice < 1 || userChoice > 2);

                switch (userChoice)
                {
                    case 1:
                        Student.StudentMenu();
                        break;
                    case 2:
                        LogInMenu();
                        break;
                }
            }
            catch (Exception)
            {
                userChoice = 0;

            }



        }


    }
}
