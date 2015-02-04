using System;
using System.Collections.Generic;

public class Developer : RegularEmployee, IDeveloper
{
    public Developer(string firstName, string lastName, uint id, decimal salary, string department, IList<Project> projects)
        : base(firstName, lastName, id, salary, department)
    {
        this.Projects = projects;
    }
    public IList<Project> Projects { get; set; }
    public override string ToString()
    {
         string result = base.ToString();
         foreach (Project project in this.Projects)
         {
             result += "\n" + project.ToString() +"\n";
         }
        return result;
    }
}

