public class IndividualMortgageAccount : MortgageAccount
{
    public IndividualMortgageAccount(string name, decimal balance, float interestRate)
        : base(name, balance, interestRate)
    {
    }

    public override decimal CalculateInterest(uint months)
    {
        return base.CalculateInterest(months - 6);
    }
}