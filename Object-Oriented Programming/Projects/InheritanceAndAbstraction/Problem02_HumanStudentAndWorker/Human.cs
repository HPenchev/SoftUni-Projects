using System;
using System.Collections.Generic;



abstract class Human
{
    private string firstName;
    private string lastName;
    public string FirstName 
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Name is mandatory");
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
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Name is mandatory");
            this.lastName = value;
        }
    }
    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}

