using System;
using System.Collections.Generic;

namespace Lab5Banks
{
    public class Bank
    {
        public double BankPercent;
        public double BankСommission;
        public TimeSpan DaysToEndTime;
        public List<Client> ClientList = new List<Client>();
        public List<BaseBankAccount> AccountList = new List<BaseBankAccount>();

        public Bank(double bankPercent, double bankComission, TimeSpan daysToEndTime)
        {
            BankPercent = bankPercent;
            BankСommission = bankComission;
            DaysToEndTime = daysToEndTime;
        }
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
        
    }
}