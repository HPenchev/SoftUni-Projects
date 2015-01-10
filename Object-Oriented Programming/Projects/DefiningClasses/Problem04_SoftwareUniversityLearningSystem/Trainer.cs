using System;

class Trainer : Person
{
    public Trainer(string firstName, string lastName, int age)
        : base(firstName, lastName, age) { }
    public void CreateCourse(string courseName)
    {
        if (string.IsNullOrEmpty(courseName)) throw new ArgumentNullException("Course name can't be empty");     
        Console.WriteLine("Course {0} has been created", courseName);
    }

}

