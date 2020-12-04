using System;

namespace Lab5Banks
{
    public abstract class AccountsWithProcents : BaseBankAccount
    {
        public double Percent;
        public double PercentCash = 0;
        public DateTime PercentAddDay;

        public AccountsWithProcents(Client owner, Bank bank, double balance) : base(owner, bank, balance)
        {
            Percent = bank.BankPercent;
            PercentAddDay = DateTime.Today;
            PercentCash = 0;
        }
        public void AddPercents()
        {
            if (DateTime.Now < PercentAddDay + TimeSpan.FromDays(365))
            {
                PercentCash += Balance / 100 * Percent / 365;
            }
            else
            {
                PercentCash += Balance / 100 * Percent / 365;
                Balance += PercentCash;
                PercentCash = 0;
                PercentAddDay = DateTime.Today;
            }
        }
    }
}