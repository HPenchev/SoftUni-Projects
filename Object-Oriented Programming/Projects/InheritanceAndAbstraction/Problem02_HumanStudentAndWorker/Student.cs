using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;



class Student : Human
{
    private string facultyNumber;
    public string FacultyNumber
    {
        get
        {
            return facultyNumber;
        }
        set
        {
            string pattern = @"[^\w]";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(value);
            if (match.Success) throw new ArgumentException("Faculty number can contain digits and letters only");
            if ((value.Length < 5) || (value.Length > 10)) throw new ArgumentOutOfRangeException("Faculty number has to contain between 5 and 10 symbols");
            this.facultyNumber = value;
        }
    }
    public Student(string firstName, string lastName, string facultyNumber)
        :base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }
}

