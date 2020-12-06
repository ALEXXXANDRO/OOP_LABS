using System;
using Lab5Banks;
using Lab5Banks.Creators;
using NUnit.Framework;

namespace BankTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var client1 = new Client("Cheburashcka", "Cheb", "box", "111");
            var client2 = new Client("Gena", "Crocodile", passport: "112");
            
            var bank = new Bank(10, 10, 50000,TimeSpan.FromMinutes(1));
            var creator1 = new CreditAccountCreator();
            
            bank.OpenBankAccount(client2,creator1,50000.2);
            bank.OpenBankAccount(client1,creator1, 10000);
            bank.BankWithdraw(client1.BankAccountList[0],500);
            
            Assert.AreEqual(9500, client1.BankAccountList[0].Balance);
            Assert.AreEqual(true, client2.BankAccountList[0].isDoubtful);
        }
        
        
        [Test]
        public void Test2()
        {
            var client1 = new Client("Cheburashcka", "Cheb", "box", "111");
            var client2 = new Client("Gena", "Crocodile", "Lake", "112");
            
            var bank = new Bank(10, 10, 50000,TimeSpan.FromMinutes(1));
            var creator1 = new CreditAccountCreator();
            
            bank.OpenBankAccount(client1,creator1,10000);
            bank.OpenBankAccount(client2,creator1, 200);
           
            bank.BankWithdraw(client1.BankAccountList[0], 500);
            bank.BankTopUp(client2.BankAccountList[0], 1000);

            Assert.AreEqual(9500, client1.BankAccountList[0].Balance);
            Assert.AreEqual(1200, client2.BankAccountList[0].Balance);
            
            bank.BankTransfer(client1.BankAccountList[0],client2.BankAccountList[0],400);
         
            Assert.AreEqual(9100, client1.BankAccountList[0].Balance);
            Assert.AreEqual(1600, client2.BankAccountList[0].Balance);
        }
        
        [Test]
        public void Test3()
        {
            var client1 = new Client("Cheburashcka", "Cheb", "box", "111");

            var bank = new Bank(3.65, 10, 50000,TimeSpan.FromMinutes(1));
            var creator1 = new DebitAccountCreator();
            
            bank.OpenBankAccount(client1,creator1,10000);
            DebitAccount account = (DebitAccount) client1.BankAccountList[0];
            account.AddPercents();

            Assert.AreEqual(1.0, account.PercentCash);
        }
        
        [Test]
        public void Test4()
        {
            var client1 = new Client("Cheburashcka", "Cheb", "box", "111");

            var bank = new Bank(3.65, 10, 50000,TimeSpan.FromMinutes(1));
            var creator1 = new CreditAccountCreator();
            
            bank.OpenBankAccount(client1,creator1,10000);
            CreditAccount account = (CreditAccount) client1.BankAccountList[0];
            
            
            bank.BankWithdraw(account,500);
            Assert.AreEqual(9500, account.Balance);
            
            bank.BankUndoLastOperation(account);
            Assert.AreEqual(10000, account.Balance);
        }
        [Test]
        public void Test5()
        {
            var client1 = new Client("Cheburashcka", "Cheb", "box", "111");

            var bank = new Bank(3.65, 10, 50000,TimeSpan.FromMinutes(1));
            var creator1 = new DebitAccountCreator();
            
            bank.OpenBankAccount(client1,creator1,10000);
            DebitAccount account = (DebitAccount) client1.BankAccountList[0];
            account.AddPercents();
            Assert.AreEqual(1.0, account.PercentCash);
            
            TimeMachine.timeMachine.ChangeDate(365);
            account.AddPercents();
            Assert.AreEqual(10002, account.Balance);
        }
    }
}