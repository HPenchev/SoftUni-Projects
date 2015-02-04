using System;
using System.Collections.Generic;



public class Discipline : IName, IDetails
{
    string name;
    private uint numberOfLectures;
    private IList<Student> students;
    private string details;
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("A discipline has to have a name");
            this.name = value;
        }
    }
    public uint NumberOfLectures
    {
        get
        {
            return this.numberOfLectures;
        }
        set
        {
            this.numberOfLectures = value;
        }
    }
    public IList<Student> Students
    {
        get
        {
            return this.students;
        }
        set
        {
            this.students = value;
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
    public Discipline(string name, uint numberOfLectures, IList<Student> students, string details = null)
    {
        this.Name = name;
        this.NumberOfLectures = numberOfLectures;
        this.Students = students;
        this.Details = details;
    }
}

