namespace StudentSystem
{
    using System;   
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Data.Migrations; 

    class Program
    {
        static void Main()
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<StudentSystemEntity, Configuration>();
            //var migrationStrategy = new DropCreateDatabaseAlways<StudentSystemEntity>();
            Database.SetInitializer(migrationStrategy);

            var context = new StudentSystemEntity();

            var studentsCount = context.Students.Count();

            //Problem 3.	Working with the Database

            //1.	Lists all students and their homework submissions. 
            //Select only their names and for each homework - content and content-type.

            //var students = context.Students
            //    .Select(s => new
            //                 {
            //                     s.Name,
            //                     Homeworks = s.Homeworks.Select(h => new
            //                                                        {
            //                                                            h.Content,
            //                                                            h.Type
            //                                                        })
            //                 });
            //foreach (var student in students)
            //{
                
            //    Console.WriteLine(student.Name);
            //    foreach (var homework in student.Homeworks)
            //    {
            //        Console.WriteLine("\tContent: " + homework.Content);
            //        Console.WriteLine("\tContent type: " + homework.Type);
            //    }

            //    Console.WriteLine();
            //}            

            //2.	List all courses with their corresponding resources. 
            //Select the course name and description and everything for each resource. 
            //Order the courses by start date (ascending), then by end date (descending).

            var courses = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                             {
                                 c.Name,
                                 c.Description,
                                 c.Resourses
                             });

            //foreach (var course in courses)
            //{
            //    Console.WriteLine("Course name: " + course.Name);
            //    Console.WriteLine("Description: " + course.Description);

            //    foreach (var resourse in course.Resourses)
            //    {
            //        Console.WriteLine("\tId: " + resourse.Id);
            //        Console.WriteLine("\tResourse name: " + resourse.Name);
            //        Console.WriteLine("\tType: " + resourse.Type);
            //        Console.WriteLine("\tURL: " + resourse.Url);
            //        Console.WriteLine();
            //    }

            //    Console.WriteLine();
            //}

            //3.	List all courses with more than 5 resources. 
            //Order them by resources count (descending), then by start date (descending). 
            //Select only the course name and the resource count.

            //var coursesByCount = context.Courses
            //    .Where(c => c.Resourses.Count() > 5)
            //    .OrderByDescending(c => c.Resourses.Count())
            //    .ThenBy(c => c.StartDate)
            //    .Select(c => new
            //                 {
            //                     c.Name,
            //                     ResourceCount = c.Resourses.Count()
            //                 });

            //foreach (var course in coursesByCount)
            //{
            //    Console.WriteLine("{0} - {1} resourses", course.Name, course.ResourceCount );
            //}

            //4.	List all courses which were active on a given date 
            //(choose the date depending on the data seeded to ensure there are results), 
            //and for each course count the number of students enrolled. Select the course name, start and end date, 
            //course duration (difference between end and start date) and number of students enrolled.
            //Order the results by the number of students enrolled (in descending order), then by duration (descending).

            var activeCourses = context.Courses
                .Where(c => c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now)
                .OrderByDescending(c => c.Students.Count())
                .ThenByDescending(c => c.EndDate - c.StartDate)
                .Select(c => new
                             {
                                 c.Name,
                                 c.StartDate,
                                 c.EndDate,
                                 CourseDuration = (c.EndDate.Ticks - c.StartDate.Ticks)/100/60/60/24,
                                 StudentsEnrolled = c.Students.Count()
                             });            

            foreach (var course in activeCourses)
            {
                Console.WriteLine("Course: {0}, Start date: {1}, End date {2}, Duration: {3} days, Students: {4}",
                    course.Name, course.StartDate, course.EndDate, course.CourseDuration, course.StudentsEnrolled);
            }

            Console.ReadLine();
        }
    }
}