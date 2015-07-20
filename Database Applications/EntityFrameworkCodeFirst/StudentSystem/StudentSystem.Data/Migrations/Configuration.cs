namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.StudentSystemEntity>
    {
        private static Random rnd = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentSystem.StudentSystemEntity";
        }

        protected override void Seed(StudentSystem.StudentSystemEntity context)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            if (context.Students.Any() || context.Courses.Any() || context.Homeworks.Any() || context.Resources.Any())
            {
                return;
            }

            context.Courses.Add(new Course()
                                {
                                    Name = "Programming Basics",
                                    Description = "Basics of programming",
                                    StartDate = DateTime.Parse("13.07.2015"),
                                    EndDate = DateTime.Parse("13.09.2015"),
                                    Price = 0m
                                });

            context.Courses.Add(new Course()
                                {
                                    Name = "Java Basics",
                                    Description = "Basics of Java",
                                    StartDate = DateTime.Parse("13.09.2015"),
                                    EndDate = DateTime.Parse("10.10.2015"),
                                    Price = 100m
                                });

            context.Courses.Add(new Course()
                                {
                                    Name = "Web Fundamentals",
                                    Description = "HTML and CSS",
                                    StartDate = DateTime.Parse("10.10.2015"),
                                    EndDate = DateTime.Parse("03.12.2015"),
                                    Price = 100m
                                });

            context.Courses.Add(new Course()
                                {
                                    Name = "Object Oriented Programming",
                                    Description = "OOP Basics, Classes, Methods",
                                    StartDate = DateTime.Parse("10.12.2015"),
                                    EndDate = DateTime.Parse("31.01.2016"),
                                    Price = 100m
                                });

            context.SaveChanges();

            var student = new Student()
            {
                Name = "Pesho Peshev",
                PhoneNumber = "0887 965 359",
                RegistrationDate = DateTime.Parse("15.02.2015"),
                BirthDate = DateTime.Parse("15.02.1990")
            };

            AddCourses(student, context);

            student = new Student()
            {
                Name = "Gosho Goshev",
                PhoneNumber = "0899 656 999",
                RegistrationDate = DateTime.Parse("15.05.2014"),
                BirthDate = DateTime.Parse("15.03.1992")
            };

            AddCourses(student, context);

            student = new Student()
            {
                Name = "Mariika Mariikina",
                PhoneNumber = "0896 555 989",
                RegistrationDate = DateTime.Parse("10.05.2015"),
                BirthDate = DateTime.Parse("15.03.1988")
            };

            AddCourses(student, context);

            student = new Student()
            {
                Name = "Pederas Pederasov",
                PhoneNumber = "0893 666 896",
                RegistrationDate = DateTime.Parse("10.01.2015"),
                BirthDate = DateTime.Parse("15.09.1986")
            };

            AddCourses(student, context);

            context.SaveChanges();

            AddResources(context);
            GenerateHomeworks(context);

            context.SaveChanges();
        }

        private static void AddResources(StudentSystem.StudentSystemEntity context)
        {
            for (int i = 0; i<24; i++)
            {
            var resource = new Resource()
            {
                Name = "Resource" + i,
                Url = "www......"
            };

            resource.Type = (TypeOfResource)rnd.Next(4);
            resource.CourseId = rnd.Next(context.Courses.Count()) + 1;
            context.Resources.Add(resource);
            }            
        }

        private static void GenerateHomeworks(StudentSystem.StudentSystemEntity context)
        {
            for (int i = 0; i < 4; i++)
            {
                var homework = new Homework()
                {
                    Content = "Some content"
                };

                homework.CourseId = rnd.Next(context.Courses.Count()) + 1;
                homework.StudentId = rnd.Next(context.Students.Count()) + 1;
                homework.Type = (HomeworkType)rnd.Next(2);                
                homework.SubmissionDate = DateTime.Now;

                context.Homeworks.Add(homework);
            }            
        }

        private static void AddCourses(Student student, StudentSystem.StudentSystemEntity context)
        {
            while (student.Courses.Count() < 2)
            {
                int courseNumber = rnd.Next(context.Courses.Count()) + 1;
                var course = context.Courses.Find(courseNumber);

                if (!student.Courses.Contains(course))
                {
                    student.Courses.Add(course);
                    context.Students.Add(student);
                }
            }
        }
    }
}