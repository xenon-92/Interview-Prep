using System;
using System.Collections.Generic;


/*
R  E  Q  U  I  R  E  M  E  N  T

An interest earning account:
Will get a credit of 2% of the month-ending-balance.

A line of credit:
Can have a negative balance, but not be greater in absolute value than the credit limit.
Will incur an interest charge each month where the end of month balance isn't 0.
Will incur a fee on each withdrawal that goes over the credit limit.

A gift card account:
Can be refilled with a specified amount once each month, on the last day of the month.

All of this account type have an action that takes place at the end of the month.
However, each account type does different tasks. 
Polymorphism can be implemented for this case. We create a virtual method in the Base class and 
override the methods in the derived class.

*/
namespace L1_Abstraction_Encapsulation
{
    /*
    Each of these classes inherits the shared behavior from their shared base class, the BankAccount class. 
    Write the implementations for new and different functionality in each of the derived classes. 
    These derived classes already have all the behavior defined in the BankAccount class.
    */

    /*
    Intially none of the code compiles.
    When you create the classes as shown in the preceding sample, 
    you'll find that none of your derived classes compile.
    A constructor is responsible for initializing an object. 
    A derived class constructor must initialize the derived class, 
    and provide instructions on how to initialize the base class object included in the derived class. 
    The proper initialization normally happens without any extra code


    */
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {

        }
        /**
        A virtual method is declared in the Base class.
        The derived class may provide different implemntation of this method.
        A virtual method is a method where any derived class may choose to reimplement. 
        The derived classes use the override keyword to define the new implementation. 
        Typically you refer to this as "overriding the base class implementation". 
        The virtual keyword specifies that derived classes may override the behavior. 
        You can also declare abstract methods where derived classes must override the behavior.
        The base class does not provide an implementation for an abstract method.
        */
        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "monthly interest....");
            }
        }
    }
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {

        }
        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                MakeWithdrawl(interest, DateTime.Now, "charge for monthly interest...");
            }
        }
        protected override Transaction CheckWithdrawalLimit(bool isOverdrawn) =>
    isOverdrawn
    ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
    : default;
    }

    public class GiftCardAccount : BankAccount
    {
        private decimal _monthlydeposit = 0;
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
        {
            this._monthlydeposit = monthlyDeposit;
        }
        public override void PerformMonthEndTransactions()
        {
            MakeDeposit(_monthlydeposit, DateTime.Now, "Add monthly deposit");
        }
    }
}