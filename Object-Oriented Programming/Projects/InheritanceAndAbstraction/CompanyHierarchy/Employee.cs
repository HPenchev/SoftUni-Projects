using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Employee : Person, IEmployee
{
    private decimal salary;
    private string department;

    public Employee(string firstName, string lastName, uint id, decimal salary, string department)
        :base(firstName, lastName, id)
    {
        this.Salary = salary;
        this.Department = department;
    }

    public decimal Salary
    { 
        get
        {
            return this.salary;
        }
        
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Salary can't be negative");
            this.salary = value;
        }
    }
    public string Department
    {
        get
        {
            return this.department;
        }
        set
        {
            if (!CheckDepartment(value)) throw new ArgumentException("Invalid department");
            this.department = value;
        }
    }

    
    private bool CheckDepartment(string department)
    {
        if(department=="Production"||department=="Accounting"||department=="Sales"||department=="Marketing")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string ToString()
    {
        string result = base.ToString();
        result += "\nSalary: " + this.Salary;
        result += "\nDepartment: " + this.Department;
        return result;
    }

}

