using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class Person : IPerson
{
    private string firstName = null;
    private string lastName = null;
    public uint Id { get; set; }
    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("First name is mandatory");
            if (nameValidation(value)) throw new ArgumentException("First name contains invalid symbols");
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
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Last name is mandatory");
            if (nameValidation(value)) throw new ArgumentException("Last name contains invalid symbols");
            this.lastName = value;
        }
    }
    public Person(string firstName, string lastName, uint id)
    {
        this.FirstName = firstName;
        this.lastName = lastName;
        this.Id = id;
    }

    protected bool nameValidation(string name)
    {
        Regex pattern = new Regex(@"[A-Za-z\-]");
        Match match = pattern.Match(name);
        return !match.Success;
    }
    public override string ToString()
    {
        string result = "First name: " + this.FirstName +"\nLast name: " + this.LastName + "\nID: " + this.Id;
        return result;
    }
}

