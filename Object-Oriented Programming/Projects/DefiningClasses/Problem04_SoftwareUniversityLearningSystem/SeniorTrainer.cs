using System;



class SeniorTrainer : Trainer
{
    public SeniorTrainer(string firstName, string lastName, int age)
        : base(firstName, lastName, age) { }
    public void DeleteCourse(string courseName)
    {
        if (string.IsNullOrEmpty(courseName)) throw new ArgumentNullException("Course name can't be empty");
        Console.WriteLine("Course {0} has been deleted", courseName);
    }
}

