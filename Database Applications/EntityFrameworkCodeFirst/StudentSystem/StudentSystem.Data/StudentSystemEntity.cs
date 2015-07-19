namespace StudentSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemEntity : DbContext
    {        
        public StudentSystemEntity()
            : base("name=StudentSystemEntity")
        {            
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}