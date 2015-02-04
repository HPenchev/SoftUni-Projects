using System;

public class Kitten : Cat
{
    private string gender = "female";
    public new string Gender
    {
        get
        {
            return this.gender;
        }
        private set { }
    }

    public Kitten(string name, sbyte age)
        :base(name, age, "female")
    {
       
    }
}

