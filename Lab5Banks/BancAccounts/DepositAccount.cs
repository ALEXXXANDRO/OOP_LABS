using System;

namespace Lab5Banks
{
    public class DepositAccount : AccountsWithProcents
    {
        public DateTime EndTime;
        public DepositAccount(Client owner, Bank bank, double balance) : base(owner, bank,balance)
        {
            EndTime = DateTime.Now + bank.DaysToEndTime;
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