using System;



class Tomcat : Cat
{
    private string gender = "male";
    public new string Gender
    {
        get
        {
            return this.gender;
        }
        private set { }
    }

    public Tomcat(string name, sbyte age)
        :base(name, age, "male")
    {
       
    }
}

