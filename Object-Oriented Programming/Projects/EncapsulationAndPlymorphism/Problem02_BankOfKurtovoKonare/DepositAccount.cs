using System;

public abstract class DepositAccount : Account, IWithdrawable
{
    public DepositAccount(string name, decimal balance, float interestRate)
        : base(name, balance, interestRate)
    {
    }

    public void Withdraw(decimal amount)
    {
        amount = Math.Round(amount, 2);

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Your withdrawal amount has to be more than 0");
        }

        this.Balance -= amount;
    }

    public override decimal CalculateInterest(uint months)
    {
        if (this.Balance > 0 && this.Balance < 1000)
        {
            return this.Balance;
        }
        else
        {
            return base.CalculateInterest(months);
        }
    }
}