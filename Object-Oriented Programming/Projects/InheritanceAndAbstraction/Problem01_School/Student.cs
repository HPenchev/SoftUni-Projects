using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Student : Person
{
    private uint uniqueClassNumber;
    public uint UniqueClassNumber
    {
        get
        {
            return this.uniqueClassNumber;
        }
        set
        {
            this.uniqueClassNumber = value;
        }
    }
    public Student(uint number, string name, string details = null)
        : base(name, details)
    {
        
        this.UniqueClassNumber = number;
    }

    
}

