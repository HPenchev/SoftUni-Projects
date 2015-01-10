using System;



class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("First name is mandatyry");
            this.firstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Last name is mandatyry");
            this.lastName = value;
        }
        
    }
    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Age can't be less than 0");
            this.age = value;
        }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }
    public override string ToString()
    {
        string output = "";
        output += "First name: " +  FirstName + "\n";
        output += "Last name: " +  LastName + "\n";
        output += "Age: " +  Age.ToString() + " years old\n";
        return string.Format(output);
    }
}

