public class DepositIndividualsAccount : DepositAccount
{
    public DepositIndividualsAccount(string name, decimal balance, float interestRate)
        : base(name, balance, interestRate)
    {
    }

    public override string Name 
    {
        get
        {
            return base.Name;
        }

        set
        {
            this.IndividualNameCheck(value);

            base.Name = value;
        }
    }
}