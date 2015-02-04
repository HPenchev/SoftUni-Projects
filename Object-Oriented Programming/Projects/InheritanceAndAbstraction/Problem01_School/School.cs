using System;
using System.Collections.Generic;


class School
{
    private IList<Class> classes;
    public IList<Class> Classes
    {
        get
        {
            return this.classes;
        }
        set
        {
            this.classes = value;
        }
    }
    public School(IList<Class> classes)
    {
        this.Classes = classes;
    }
}

