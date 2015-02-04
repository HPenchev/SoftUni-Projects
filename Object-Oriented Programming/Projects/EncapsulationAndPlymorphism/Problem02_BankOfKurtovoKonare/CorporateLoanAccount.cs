public class CorporateLoanAccount : LoanAccount
{
    public CorporateLoanAccount(string name, decimal balance, float interestRate)
        : base(name, balance, interestRate)
    {
    }

    public override sbyte MonthsOfDiscount
    {
        get
        {
            return 2;
        }
    }
}