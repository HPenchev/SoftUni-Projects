using System;
using System.Text.RegularExpressions;

public abstract class Account : IDepositable
{
    private string name;
       
    public Account(string name, decimal balance, float interestRate)
    {
        this.Name = name;
        this.Balance = balance;
        this.InterestRate = interestRate;
    }

    public virtual string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name can't be empty");
            }

            this.name = value;
        }
    }

    public decimal Balance { get; set; }

    public float InterestRate { get; set; }    

    public void Deposit(decimal amount)
    {
        amount = Math.Round(amount, 2);

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Deposit amount has to be more than 0");
        }

        this.Balance += amount;
    }

    public virtual decimal CalculateInterest(uint months)
    {
        decimal finalAmount = this.Balance * (decimal)(1 + (this.InterestRate / 100 * months));
        
        return finalAmount;
    }

    protected void IndividualNameCheck(string name)
    {
        Regex r = new Regex(@"[^A-Za-z\s\-]");
        Match match = r.Match(name);

        if (match.Success)
        {
            throw new ArgumentException("Invalid name");
        }
    }
}