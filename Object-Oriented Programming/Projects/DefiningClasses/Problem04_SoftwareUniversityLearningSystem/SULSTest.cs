using System;
using System.Collections.Generic;
using System.Linq;



class SLUSTest
{
    static void Main()
    {

        List<Person> softUniPeople = new List<Person>();
        string checker = null;
        uint studentNumber = 0u;
        float averageGrade = 0f;
        string currentCourse = null;
        uint numberOfVisits = 0u;
        string dropoutReason = null;
        do
        {
            Person temp;
            Console.WriteLine("Please choose a type of object:");
            Console.WriteLine("1 - Person");
            Console.WriteLine("2 - Trainer");
            Console.WriteLine("3 - Junior Trainer");
            Console.WriteLine("4 - Senior Trainer");
            Console.WriteLine("5 - Student");
            Console.WriteLine("6 - GraduateStudent");
            Console.WriteLine("7 - CurrentStudent");
            Console.WriteLine("8 - Online Student");
            Console.WriteLine("9 - Onsite Student");
            Console.WriteLine("10 - Dropout Student");
            byte typeOfObject = byte.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter a last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter an age:");
            int age = int.Parse(Console.ReadLine());
            if (typeOfObject >= 5)
            {
                Console.WriteLine("Please enter a student number:");
                studentNumber = uint.Parse(Console.ReadLine());
                Console.WriteLine("Please enter an average grade:");
                averageGrade = float.Parse(Console.ReadLine());
                if (typeOfObject >= 7 && typeOfObject <= 9)
                {
                    Console.WriteLine("Please enter student current course:");
                    currentCourse = Console.ReadLine();
                    if (typeOfObject == 9)
                    {
                        Console.WriteLine("Please enter a numebr of visits:");
                        numberOfVisits = uint.Parse(Console.ReadLine());
                    }
                }
                else if (typeOfObject == 10)
                {
                    Console.WriteLine("Please enter dropout reason");
                    dropoutReason = Console.ReadLine();
                }
            }
            switch (typeOfObject)
            {
                case (1): temp = new Person(firstName, lastName, age); break;
                case (2): temp = new Trainer(firstName, lastName, age); break;
                case (3): temp = new JuniorTrainer(firstName, lastName, age); break;
                case (4): temp = new SeniorTrainer(firstName, lastName, age); break;
                case (5): temp = new Student(firstName, lastName, age, studentNumber, averageGrade); break;
                case (6): temp = new GraduateStudent(firstName, lastName, age, studentNumber, averageGrade); break;
                case (7): temp = new CurrentStudent(firstName, lastName, age, studentNumber, averageGrade, currentCourse); break;
                case (8): temp = new OnlineStudent(firstName, lastName, age, studentNumber, averageGrade, currentCourse); break;
                case (9): temp = new OnsiteStudent(firstName, lastName, age, studentNumber, averageGrade, currentCourse, numberOfVisits); break;
                case (10): temp = new DropoutStudent(firstName, lastName, age, studentNumber, averageGrade, dropoutReason); break;
                default:
                    Console.WriteLine("Invalid object type");
                    continue;

            }

            Console.WriteLine("Would you like to print the current object? Y\\N");
            checker = Console.ReadLine();
            if (checker == "Y" || checker == "y")
            {
                Console.WriteLine(temp.ToString());
            }
            if (typeOfObject >= 2 && typeOfObject <= 4)
            {
                Console.WriteLine("Would you like to add a course? Y\\N");
                checker = Console.ReadLine();
                if (checker == "Y" || checker == "y")
                {
                    Console.WriteLine("Please enter a course name:");
                    string course = Console.ReadLine();
                    Trainer tempTrainer = (Trainer)temp;
                    tempTrainer.CreateCourse(course);
                }
                if (typeOfObject == 4)
                {
                    Console.WriteLine("Would you like to delete a course? Y\\N");
                    checker = Console.ReadLine();
                    if (checker == "Y" || checker == "y")
                    {
                        Console.WriteLine("Please enter a course name:");
                        string course = Console.ReadLine();
                        SeniorTrainer tempTrainer = (SeniorTrainer)temp;
                        tempTrainer.DeleteCourse(course);
                    }
                }
            }
            if (typeOfObject == 10)
            {
                Console.WriteLine("Would you like to reapply? Y\\N");
                checker = Console.ReadLine();
                if (checker == "Y" || checker == "y")
                {

                    DropoutStudent tempStudent = (DropoutStudent)temp;
                    tempStudent.Reapply();
                }
            }
            softUniPeople.Add(temp);
            Console.WriteLine("Would you like to add another object? Y\\N");
            checker = Console.ReadLine();
        } while (checker != "N" && checker != "n");
        
        softUniPeople.Where(p => p is CurrentStudent).OrderBy(p => ((CurrentStudent)p).AverageGrade).ToList().ForEach(p=> Console.WriteLine(p.ToString())); 
        
        
    }
}

