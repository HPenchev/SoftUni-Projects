using System;
using System.Collections.Generic;



class Teacher : Person
{
    private IList<Discipline> disciplines;
    public IList<Discipline> Disciplines
    {
        get
        {
            return this.disciplines;
        }
        set
        {
            this.disciplines = value;
        }
    }

    public global::Discipline Discipline
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    public Teacher(string name, IList<Discipline> disciplines, string details = null) : base(name, details) 
    {
        
        this.Disciplines = disciplines;
      
    }
    
}

