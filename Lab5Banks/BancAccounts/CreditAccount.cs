using System;

namespace Lab5Banks
{
    public class CreditAccount : BaseBankAccount
    {
        public double CreditLimit;
        public double Commission;

        public override void Withdraw(int cash)
        {
            if(isDoubtful) throw new DoubtfulAccount();
            if(cash + Commission> CreditLimit + this.Balance) throw new NotEnoughMoney();
            if (Balance < 0)
                Balance -= (cash + Commission);
            else
            {
                Balance -= cash;
            }

        }

        public CreditAccount(Client owner, Bank bank, double balance) : base(owner, bank, balance)
        {
            Commission = bank.BankСommission;
            CreditLimit = bank.BankCreditLimit;
        }
    }
}