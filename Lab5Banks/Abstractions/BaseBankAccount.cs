using System;
using System.Collections.Generic;

namespace Lab5Banks
{
    public abstract class BaseBankAccount
    {
        protected Bank BankOwner;
        protected Client Owner;
        public double Balance;
        public bool isDoubtful;
        
        public List<BaseCommand> CommandHistory = new List<BaseCommand>();

        public BaseBankAccount(Client owner, Bank bank, double balance)
        {
            BankOwner = bank;
            Owner = owner;
            Balance = balance;
            isDoubtful = (owner.Passport == null || owner.Address == null);
        }

        public double GetBalance()
        {
            return Balance;
        }
        
        public void TopUp(double cash)
        {
            this.Balance += cash;
        }
        public void Transfer(double cash, BaseBankAccount account)
        {
            if (account == null) throw new WrongAccount();
            this.Withdraw(cash);
            account.TopUp(cash);
        }
        public virtual void Withdraw(double cash)
        {
            if(isDoubtful) throw new DoubtfulAccount();
            if(cash > this.Balance) throw new NotEnoughMoney();
            this.Balance -= cash;
        }
    }
}