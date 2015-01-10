using System;



class Student: Person
{
    private uint studentNumber;
    private float averageGrade;

    public uint StudentNumber
    {
        get
        {
            return this.studentNumber;
        }
        set
        {
            this.studentNumber = value;
        }
    }
    public float AverageGrade
    {
        get
        {
            return this.averageGrade;
        }
        set
        {
            if (value < 2 || value > 6) throw new ArgumentOutOfRangeException("Grades can be between 2.00 and 6.00");
            this.averageGrade = value;
        }
    }
    public Student(string firstName, string lastName, int age, uint studentNumber, float averageGrade)
        :base(firstName, lastName, age)
    {
        this.StudentNumber = studentNumber;
        this.AverageGrade = averageGrade;
    }
    public override string ToString()
    {
        string output = base.ToString();
        output += "Student number: " + StudentNumber + "\n";
        output += "Average Grade: " + AverageGrade + "\n";
        return string.Format(output);
    }
}

