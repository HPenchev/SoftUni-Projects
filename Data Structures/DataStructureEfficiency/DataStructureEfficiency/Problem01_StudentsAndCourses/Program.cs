using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01_StudentsAndCourses
{
    class Program
    {
        static SortedDictionary<String, SortedSet<Person>> peopleInCourses =
                new SortedDictionary<String, SortedSet<Person>>();

        static void Main()
        {
            SeedInformationFromFile();

            PrintStudentsByCourse();
        }

        private static void PrintStudentsByCourse()
        {
            foreach (var course in peopleInCourses.Keys)
            {
                Console.WriteLine(course + ":");
                foreach (var student in peopleInCourses[course])
                {
                    Console.WriteLine("\t" + student.LastName + " " + student.FirstName);
                }
            }
        }

        private static void SeedInformationFromFile()
        {
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(@"..//..//test.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] input = line.Split('|');
                var person = new Person()
                {
                    FirstName = input[0].Trim(),
                    LastName = input[1].Trim()
                };

                string course = input[2].Trim();

                if (!peopleInCourses.ContainsKey(course))
                {
                    peopleInCourses.Add(course, new SortedSet<Person>());
                }

                peopleInCourses[course].Add(person);
            }
        }
    }
}
