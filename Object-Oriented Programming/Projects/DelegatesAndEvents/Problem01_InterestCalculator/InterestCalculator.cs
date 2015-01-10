using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class InterestCalculator
{
    private decimal money;
    private float interest;
    private int years;
    private CalculateInterest interestCalculation;
    private decimal moneyAfterIdexation;

    public decimal Money
    {
        get
        {
            return this.money;
        }
        set
        {
            this.money = value;
        }

    }
    public float Interest
    {
        get
        {
            return this.interest;
        }
        set
        {
            this.interest = value;
        }
    }
    public int Years
    {
        get
        {
            return this.years;
        }
        set
        {
            if (value <=0) throw new ArgumentException("Years have to be more than 0");
            this.interest = value;
        }
    }
    public decimal MoneyAfterIdexation
    {
        get
        {
            return this.moneyAfterIdexation;
        }
        set
        {
            this.moneyAfterIdexation = value;
        }
    }
    public CalculateInterest InterestCalculation
    {
        get
        {
            return this.interestCalculation;
        }
        set
        {
            this.interestCalculation = value;
        }
    }
    public InterestCalculator(decimal money, float interest, int years, CalculateInterest interestCalculation)
    {
        this.Money = money;
        this.Interest = interest;
        this.Years = years;
        this.InterestCalculation = interestCalculation;
        this.MoneyAfterIdexation = InterestCalculation(money, interest, years);
    }
}

