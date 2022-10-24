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

        public static List<string> meetingDay = new List<string>();
        public static List<string> meetingTime = new List<string>();
        public static List<string> meetingSupervisor = new List<string>();
        public static List<string> meetingsBooked = new List<string>();


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
            int indexNumber2 = 0;
            bool validUsername = false;

            Console.WriteLine("=================");
            Console.WriteLine("Welcome to the Support App");
            Console.WriteLine("=================\n");
            Console.WriteLine("=================");
            Console.WriteLine("Log In");
            Console.WriteLine("=================");
            Console.WriteLine("Type exit to exit App\n");

            while (validUsername == false)
            {
                indexNumber = 0;
                Console.Write("Please enter a user name: ");

                try
                {
                    
                    userName = Console.ReadLine();

                   

                    if (userName == "exit" || userName == "Exit")
                    {
                        Environment.Exit(1);
                    }
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
 
                    while (userPassword != storedUserPassowrd[indexNumber])
                    {
                        Console.Write("\nPlease enter a password: ");
                        userPassword = Console.ReadLine();
                    }
                    try
                    {
                   
                        if (userPassword == storedUserPassowrd[indexNumber])
                        {
                           
                            if (userType == "Student")
                            {
                                foreach (string user in storedUserName)
                                {
                                    if (storedUserName[indexNumber2] == userName && storedUserPassowrd[indexNumber2] == userPassword)
                                    {
                                        Student student = new Student(personName[indexNumber2], storedUserName[indexNumber2], storedUserPassowrd[indexNumber2], personalSupervisor[indexNumber2]);
                                        Student.StudentMenu();
                                    }
                                    indexNumber2++;
                                }
                                
                            }
                            else if (userType == "PS")
                            {
                                foreach (string user in storedUserName)
                                {
                                    if (storedUserName[indexNumber2] == userName && storedUserPassowrd[indexNumber2] == userPassword)
                                    {
                                        PersonalSupervisor supervisor = new PersonalSupervisor(personName[indexNumber2], storedUserName[indexNumber2], storedUserPassowrd[indexNumber2]);
                                        PersonalSupervisor.PersonalSupervisorMenu();
                                    }
                                    indexNumber2++; 
                                }
                                
                   
                            }
                            else if (userType == "ST")
                            {
                                foreach (string user in storedUserName)
                                {
                                    if (storedUserName[indexNumber2] == userName && storedUserPassowrd[indexNumber2] == userPassword)
                                    {
                                        SeniorTutor seniorTutor = new SeniorTutor(personName[indexNumber2], storedUserName[indexNumber2], storedUserPassowrd[indexNumber2]);
                                        SeniorTutor.SeniorTutorMenu();
                                    }
                                    indexNumber2++;
                                }
                              
                            }

                        }
                    }
                    catch (Exception)
                    {
                        LogInMenu();
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

        public static void LogOutOrContine(in string jobtype)
        {
            int userChoice = 0;

            Console.WriteLine("\n========================");
            Console.WriteLine("1. Main menu");
            Console.WriteLine("2. Log out");
            Console.WriteLine("3. Exit\n");


            try
            {
                do
                {
                    Console.WriteLine("Please enter a value between 1 and 2");
                    userChoice = int.Parse(Console.ReadLine());
                } while (userChoice < 1 || userChoice > 3);

                switch (userChoice)
                {
                    case 1:
                        if (jobtype == "student")
                        {
                            Console.Clear();
                            Student.StudentMenu();
                        }
                        else if (jobtype == "ps")
                        {
                            Console.Clear();
                            PersonalSupervisor.PersonalSupervisorMenu();
                        }
                        else if (jobtype == "st")
                        {
                            Console.Clear();
                            SeniorTutor.SeniorTutorMenu();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        LogInMenu();
                        break;
                    case 3:
                        Environment.Exit(1); 
                        break;
                }
            }
            catch (Exception)
            {
                userChoice = 0;

            }



        }

        public static void GetMeetingTimes()
        {
            string filePath = @"meetings.csv"; //File that needs to be read
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


                        meetingDay.Add(values[0]);       
                        meetingTime.Add(values[1]);      
                        meetingSupervisor.Add(values[2]);
                        if (values[3] == null)
                        {
                            meetingsBooked.Add("");
                        }
                        else
                        {
                            meetingsBooked.Add(values[3]);
                        }
                       
                       


                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error occored loading meetings please try again");
                    }


                }
            }


        }

        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }


    }
}
