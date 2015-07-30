namespace ATM
{
    using System;
    using System.Linq;
    using System.Transactions;

    public class TransactionUtilities
    {
        public static void WithdrawMoney(
            ATMEntities context, 
            string cardNumber, 
            string cardPin, 
            decimal amount)
        {
            using (var tran = 
                context.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                try
                {
                    if (cardNumber.Length != 10 || cardPin.Length != 4 || amount <=0)
                    {
                        throw new ArgumentException
                            ("Some of the arguments passed are invalid");
                    }

                    var accounts = context.CardAccounts.Where(a => a.CardNumber == cardNumber);



                    if (accounts == null)
                    {
                        throw new ArgumentException("No such card in database");
                    }

                    if (accounts.Count() > 1)
                    {
                        throw new ArgumentException("Database contains more than one card" + 
                            " with such number");
                    }

                    if (accounts.First().CardCash < amount)
                    {
                        throw new InvalidOperationException("Not enough cash in account");
                    }

                    if (accounts.First().CardPIN != cardPin)
                    {
                        throw new ArgumentException("Invalid PIN");
                    }

                    var account = accounts.First();
                    account.CardCash = account.CardCash - amount;
                    context.SaveChanges();

                    tran.Commit();

                    RecordTransaction(context, cardNumber, amount);
                }
                catch(Exception e)
                {
                    tran.Rollback();
                    throw (e);
                }
            }
        }

        private static void RecordTransaction(
            ATMEntities context,
            string cardNumber,
            decimal amount)
        {
            using (var tran =
                context.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                try
                {
                    var transactionRecord = new TransactionHistory();
                    transactionRecord.CardNumber = cardNumber;
                    transactionRecord.TransactionDate = DateTime.Now;
                    transactionRecord.Amount = amount;
                    context.TransactionHistories.Add(transactionRecord);  
                    

                    context.SaveChanges();

                    tran.Commit();

                    //Console.WriteLine(accounts.First().CardCash -= amount);
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw (e);
                }
            }
        }
    }
}