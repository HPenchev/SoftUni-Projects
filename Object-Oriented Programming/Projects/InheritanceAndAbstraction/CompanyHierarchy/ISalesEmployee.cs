using System;
using System.Collections.Generic;

public interface ISalesEmployee
{
    IList<Sale> Sales { get; set; }
    string ToString();
}

