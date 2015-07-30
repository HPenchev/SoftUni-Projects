using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            var context = new ATMEntities();
            string cardNumber = "6598956359";
            string pinNumber = "9896";
            decimal amount = 20m;

            TransactionUtilities.WithdrawMoney(context, cardNumber, pinNumber, amount);
            var remainingAmount = context.CardAccounts
                .Where(c => c.CardNumber == cardNumber)
                .Select(c => c.CardCash).First();

            Console.WriteLine(remainingAmount);



        }
    }
}
