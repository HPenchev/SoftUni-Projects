using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    public class CoursesExamples
    {
        static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse.ToString());

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse.ToString());

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse.ToString());

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse.ToString());

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse.ToString());
        }
    }
}
