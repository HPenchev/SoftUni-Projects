using System;



class OnsiteStudent : CurrentStudent
{
    private uint numberOfVisits;
    public uint NumberOfVisits
    {
        get 
        {
            return this.numberOfVisits;
        }
        set
        {
            this.numberOfVisits = value;

        }
    }
    public OnsiteStudent(string firstName, string lastName, int age, uint studentNumber, float averageGrade, string currentCourse, uint numberOfVisits)
        : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
    {
        this.NumberOfVisits = numberOfVisits;
    }
    public override string ToString()
    {
        string output = base.ToString();
        output += "Number of visits: " + NumberOfVisits + "\n";
        return string.Format(output);
    }
}

