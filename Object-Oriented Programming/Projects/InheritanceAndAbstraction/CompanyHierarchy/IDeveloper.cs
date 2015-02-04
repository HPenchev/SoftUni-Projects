using System;
using System.Collections.Generic;

public interface IDeveloper : IRegularEmployee
{
    IList<Project> Projects { get; set; }
    
}

