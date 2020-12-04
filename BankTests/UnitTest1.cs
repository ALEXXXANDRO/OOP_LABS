using System;
using Lab5Banks;
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
            
            var bank = new Bank(10, 10, TimeSpan.FromMinutes(1));
            bank.OpenBankAccount<CreditAccount>(client1, 10000); 
            bank.OpenBankAccount<CreditAccount>(client2, 200);

            client1.BankAccountList[0].Withdraw(500);
            Assert.AreEqual(9500, client1.BankAccountList[0].Balance);
            Assert.AreEqual(true, client2.BankAccountList[0].isDoubtful);
        }
        
        
        [Test]
        public void Test2()
        {
            var client1 = new Client("Cheburashcka", "Cheb", "box", "111");
            var client2 = new Client("Gena", "Crocodile", "Lake", "112");
            
            var bank = new Bank(10, 10, TimeSpan.FromMinutes(1));
            bank.OpenBankAccount<CreditAccount>(client1, 10000); 
            bank.OpenBankAccount<CreditAccount>(client2, 200);

            client1.BankAccountList[0].Withdraw(500);
            client2.BankAccountList[0].TopUp(1000);
            
            Assert.AreEqual(9500, client1.BankAccountList[0].Balance);
            Assert.AreEqual(1200, client2.BankAccountList[0].Balance);
            
            client1.BankAccountList[0].Transfer(400, client2.BankAccountList[0]);
            Assert.AreEqual(9100, client1.BankAccountList[0].Balance);
            Assert.AreEqual(1600, client2.BankAccountList[0].Balance);
        }
        
        [Test]
        public void Test3()
        {
            var client1 = new Client("Cheburashcka", "Cheb", "box", "111");

            var bank = new Bank(3.65, 10, TimeSpan.FromDays(1));
            var account = bank.OpenBankAccount<DebitAccount>(client1, 10000);

            account.AddPercents();

            Assert.AreEqual(1.0, account.PercentCash);
        }
    }
}