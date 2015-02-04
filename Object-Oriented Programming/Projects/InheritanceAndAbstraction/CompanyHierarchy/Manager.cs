using System;
using System.Collections.Generic;



public class Manager : Employee, IManager
{
    public Manager(string firstName, string lastName, uint id, decimal salary, string department, IList<Employee> subordinates)
        :base(firstName, lastName, id, salary, department)
    {
        this.Subordinates = subordinates;
    }
    public IList<Employee> Subordinates { get; set; }
    public override string ToString()
    {
        string result = base.ToString();
        result += "\nSubordinates:\n";
        foreach (Employee subordinate in this.Subordinates)
        {
            result += subordinate.ToString() + "\n";
        }
        return result;
    }
}

