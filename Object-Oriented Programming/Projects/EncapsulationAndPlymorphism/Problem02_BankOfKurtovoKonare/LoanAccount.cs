public abstract class LoanAccount : Account
{
    public LoanAccount(string name, decimal balance, float interestRate)
        : base(name, balance, interestRate)
    {
    }

    public abstract sbyte MonthsOfDiscount { get; }

    public override decimal CalculateInterest(uint months)
    {
        if (months < this.MonthsOfDiscount)
        {
            return this.Balance;
        }
        else
        {            
            return base.CalculateInterest((uint)(months - this.MonthsOfDiscount));
        }
    }
}