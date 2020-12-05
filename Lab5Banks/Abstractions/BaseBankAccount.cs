using System;

namespace Lab5Banks
{
    public abstract class BaseBankAccount
    {
        protected Bank BankOwner;
        protected Client Owner;
        public double Balance;
        public bool isDoubtful;

        public BaseBankAccount(Client owner, Bank bank, double balance)
        {
            BankOwner = bank;
            Owner = owner;
            Balance = balance;
        }

        public double GetBalance()
        {
            return Balance;
        }
        
        public void TopUp(int cash)
        {
            this.Balance += cash;
        }
        public void Transfer(int cash, BaseBankAccount account)
        {
            if (account == null) throw new WrongAccount();
            this.Withdraw(cash);
            account.TopUp(cash);
        }
        public virtual void Withdraw(int cash)
        {
            if(isDoubtful) throw new DoubtfulAccount();
            if(cash > this.Balance) throw new NotEnoughMoney();
            this.Balance -= cash;
        }
    }
}