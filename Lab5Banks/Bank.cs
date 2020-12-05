using System;
using System.Collections.Generic;


namespace Lab5Banks
{
    public class Bank
    {
        public List<Client> ClientList = new List<Client>();
        public List<BaseBankAccount> AccountList = new List<BaseBankAccount>();
        public double BankPercent;
        public double BankСommission;
        public double BankCreditLimit;
        public TimeSpan DaysToEndTime;
        
        public Bank(double bankPercent, double bankComission, double bankCreditLimit, TimeSpan daysToEndTime)
        {
            BankPercent = bankPercent;
            BankСommission = bankComission;
            BankCreditLimit = bankCreditLimit;
            DaysToEndTime = daysToEndTime;
        }

        public void OpenBankAccount(Client client, IAccountCreator creator, double balance)
        {
            var account = creator.CreateAccount(client,this, balance);
            client.BankAccountList.Add(account);
            this.AccountList.Add(account);
        }

        public void SetProcents(DepositAccount account)
        {
            if (account.Balance < 50000) {account.Percent = 3;}
            if (account.Balance > 100000) {account.Percent = 4;}
            else {account.Percent = 3.5;}
        }
        
        
        /*
        public T OpenBankAccount<T>(Client client, double cash) 
            where T : BaseBankAccount
        {
            var account = System.Activator.CreateInstance(typeof(T), client, this, cash) as T;
            client.BankAccountList.Add(account);
            AccountList.Add(account);
            if (!ClientList.Contains(client))
            {
                ClientList.Add(client);
            }
            return account;
        }
         */
    }
}