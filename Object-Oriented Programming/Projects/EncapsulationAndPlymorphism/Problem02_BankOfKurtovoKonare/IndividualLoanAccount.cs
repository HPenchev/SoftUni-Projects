public class IndividualLoanAccount : LoanAccount
{
    public IndividualLoanAccount(string name, decimal balance, float interestRate)
        : base(name, balance, interestRate)
    {
    }

    public override sbyte MonthsOfDiscount
    {
        get 
        {
            return 3;
        }
    }
}