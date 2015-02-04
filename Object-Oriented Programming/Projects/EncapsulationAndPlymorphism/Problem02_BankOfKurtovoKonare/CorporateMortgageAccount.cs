public class CorporateMortgageAccount : MortgageAccount
{
    public CorporateMortgageAccount(string name, decimal balance, float interestRate)
        : base(name, balance, interestRate)
    {
    }

    public override decimal CalculateInterest(uint months)
    {
        if (months <= 12)
        {
            return this.Balance * (decimal)(1 + (this.InterestRate / 2 / 100 * months));
        }
        else
        {
            decimal finalAmount = this.Balance * (decimal)(1 + (this.InterestRate / 2 / 100 * 12));
            finalAmount += base.CalculateInterest(months - 12);

            return finalAmount;
        }
    }
}