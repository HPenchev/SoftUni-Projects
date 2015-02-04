using System;
using System.Collections.Generic;


public interface IManager : IEmployee
{
    IList<Employee> Subordinates { get; set; }
}

