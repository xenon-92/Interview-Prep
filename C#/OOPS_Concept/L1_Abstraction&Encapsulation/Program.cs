using System;

namespace L1_Abstraction_Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var giftCard = new GiftCardAccount("Gift card", 100, 50);
                giftCard.MakeWithdrawl(20, DateTime.Now, "get expensive coffee");
                giftCard.MakeWithdrawl(50, DateTime.Now, "buy amazon groceries..");
                giftCard.PerformMonthEndTransactions();
                //make deposits
                giftCard.MakeDeposit(20, DateTime.Now, "top up gift card");
                System.Console.WriteLine(giftCard.GetAccountHistory());

                var savings = new InterestEarningAccount("Savings account", 10000);
                savings.MakeDeposit(100, DateTime.Now, "save some money");
                savings.MakeDeposit(1200, DateTime.Now, "save more money");
                savings.MakeWithdrawl(352, DateTime.Now, "pay monthly electricity bills...");
                savings.PerformMonthEndTransactions();
                System.Console.WriteLine(savings.GetAccountHistory());

                var lineOfCredit = new LineOfCreditAccount("LOC", 0, 2000);
                lineOfCredit.MakeWithdrawl(1000, DateTime.Now, "Take out monthly advance..");
                lineOfCredit.MakeDeposit(80, DateTime.Now, "Pay back small amount");
                lineOfCredit.MakeWithdrawl(5000m, DateTime.Now, "Emergency funds for repairs");
                lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
                lineOfCredit.PerformMonthEndTransactions();

                System.Console.WriteLine(lineOfCredit.GetAccountHistory());
            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine(ex.ToString());
            }

        }
    }
}
