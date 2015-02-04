using System;



class Worker : Human
{
    private double workHoursPerDay = 0;
    private decimal weekSalary = 0;
    private sbyte workingDaysPerWeek = 5;
    public double WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            if (value < 0 || value > 24) throw new ArgumentOutOfRangeException("Daily work hours have to be between 0 and 24");
            this.workHoursPerDay = value;
        }
    }
    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if(value < 0) throw new ArgumentOutOfRangeException("Weekly salary can't be negative");
            this.weekSalary = value;
        }
    }
    public sbyte WorkingDaysPerWeek
    {
        get
        {
            return this.workingDaysPerWeek;
        }
        set
        {
            if (value > 7) throw new ArgumentOutOfRangeException("Working days can't be more than 7");
            this.workingDaysPerWeek = value;
        }
    }
    public Worker(string firstName, string lastName, double workHoursPerDay, decimal weekSalary)
        : base(firstName, lastName)
    {
        this.WorkHoursPerDay = workHoursPerDay;
        this.WeekSalary = weekSalary;
    }
    public decimal MoneyPerHour() 
    {
        decimal moneyPerHour = this.WeekSalary / (decimal)(this.WorkHoursPerDay * this.WorkingDaysPerWeek);
        
        return Math.Round(moneyPerHour, 2);
    }
}

