using System;


public class RegularEmployee : Employee, IRegularEmployee
{
    public RegularEmployee(string firstName, string lastName, uint id, decimal salary, string department)
        : base(firstName, lastName, id, salary, department) { }
}

