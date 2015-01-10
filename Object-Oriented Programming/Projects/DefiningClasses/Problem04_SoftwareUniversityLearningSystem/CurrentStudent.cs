using System;



class CurrentStudent : Student
{
    private string currentCourse;
    
    public string CurrentCourse
    {
        get 
        {
            return this.currentCourse;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Current Course can't be empty");
            this.currentCourse = value;
        }
    }
    public CurrentStudent(string firstName, string lastName, int age, uint studentNumber, float averageGrade, string currentCourse)
        :base(firstName, lastName, age, studentNumber, averageGrade)
    {
        this.CurrentCourse = currentCourse;
    }
    public override string ToString()
    {
        string output = base.ToString();
        output += "Current course: " + CurrentCourse + "\n";
        return string.Format(output);
    }

}

