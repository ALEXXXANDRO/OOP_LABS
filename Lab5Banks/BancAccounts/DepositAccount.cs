using System;

namespace Lab5Banks
{
    public class DepositAccount : AccountsWithProcents
    {
        public DateTime EndTime;
        public DepositAccount(Client owner, Bank bank, double balance) : base(owner, bank,balance)
        {
            if (balance < 50000) {Percent = 3;}
            if (balance > 100000) {Percent = 4;}
            else {Percent = 3.5;}

            EndTime = DateTime.Now + BankOwner.DaysToEndTime;
        }

        public override void Withdraw(int cash)
        {
           if(DateTime.Now <= EndTime) throw new EndTimeError($"Вы не сможете снять деньги до {EndTime}");
           if(isDoubtful) throw new DoubtfulAccount();
           if(cash > this.Balance) throw new NotEnoughMoney();
           this.Balance -= cash;
        }
    }
}