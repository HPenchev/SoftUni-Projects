using System;
using System.Collections.Generic;

public class SalesEmployee : RegularEmployee, ISalesEmployee
{
    public SalesEmployee(string firstName, string lastName, uint id, decimal salary, string department, IList<Sale> sales)
        : base(firstName, lastName, id, salary, department)
    {
        this.Sales = sales;
    }
    public IList<Sale> Sales { get; set; }
    public override string ToString()
    {
        string result = base.ToString();
        foreach (Sale sale in this.Sales)
        {
            result += "\n" + sale.ToString();
        }
        return result;
    }
}

