using System;
using System.Collections.Generic;



class Class : IDetails
{
    private string uniqueTextIdentifier;
    private string details;
    private IList<Teacher> teachers;
    private IList<Student> students;
    public string UniqueTextIdentifier
    {
        get
        {
            return this.uniqueTextIdentifier;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Text Identifier is required in a class");
            this.uniqueTextIdentifier = value;
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
    public IList<Teacher> Teachers
    {
        get
        {
            return this.teachers;
        }
        set
        {
            this.teachers = value;
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
    public Class(string textIdentifier, IList<Teacher> teachers, IList<Student> students, string details = null)
    {
        this.UniqueTextIdentifier = textIdentifier;
        this.Teachers = teachers;
        this.Details = details;
        this.Students = students;
    }
}

