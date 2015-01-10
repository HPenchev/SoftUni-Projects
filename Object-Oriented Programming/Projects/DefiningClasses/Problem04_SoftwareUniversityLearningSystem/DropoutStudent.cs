using System;



class DropoutStudent : Student
{
    private string dropoutReason;
    public string DropoutReason
    {
        get
        {
            return this.dropoutReason;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Dropout reason is mandatory");
            this.dropoutReason = value;
        }
    }
    public DropoutStudent(string firstName, string lastName, int age, uint studentNumber, float averageGrade, string dropoutReason)
        :base(firstName, lastName, age, studentNumber, averageGrade)
    {
        this.DropoutReason = dropoutReason;
    }
    public override string ToString()
    {
        string output = base.ToString();
        output += "Dropout reason: " + DropoutReason + "\n";        
        return string.Format(output);
    }
    public void Reapply()
    {
        Console.WriteLine(this.ToString());
    }
}


