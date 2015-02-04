using System;
using System.Collections.Generic;

public class BankTest
{
    public static void Main()
    {
        List<Account> accounts = new List<Account>();

        accounts.Add(new DepositCorporateAccount("Microsoft Ltd", 1000m, 1));
        accounts.Add(new DepositIndividualsAccount("Petar Ivanov", 999m, 1));
        accounts.Add(new CorporateLoanAccount("Apple", 1000m, 1));
        accounts.Add(new IndividualLoanAccount("Ivan Petrov", 1000m, 1));
        accounts.Add(new CorporateMortgageAccount("BMW", 1000m, 1));
        accounts.Add(new IndividualMortgageAccount("Nikolay Stoyanov", 1000m, 1));

        for (int i = 0; i < accounts.Count; i++)
		{
             uint months = 0;
			 if (i < 2)
             {
                 months = 12;
             }
             else if (i < 4)
             {
                 months = 3;
             }
             else
             {
                months = 10;
             }

            Console.WriteLine(accounts[i].Name + ": " + accounts[i].CalculateInterest(months));
		}
    }
}