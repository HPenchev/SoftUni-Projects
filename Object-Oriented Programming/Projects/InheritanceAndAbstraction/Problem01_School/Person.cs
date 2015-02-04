using System;


public abstract class Person: IName, IDetails
{
    private string name;
    private string details;
    public string Name 
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("A person has to have a name");
            this.name = value;
        }
    }
    public string Details
    { 
        get
        {
            return this.details;
        }
            
        set
        {
            this.details = value;
        }
    }
    public Person(string name, string details = null)
    {
        this.Name = name;
        this.Details = details;
    }
}

