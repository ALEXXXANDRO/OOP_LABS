using System;

namespace Lab5Banks
{
    public abstract class BaseBankAccount
    {
        public Bank BankOwner;
        public Client Owner;
        public double Balance;
        public bool isDoubtful;

        public BaseBankAccount(Client owner, Bank bank, double balance)
        {
            BankOwner = bank;
            Owner = owner;
            Balance = balance;
            CheckDoubtful();
        }
        
        public void CheckDoubtful()
        {
            isDoubtful = !(Owner.Passport != null && Owner.Address != null);
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