using System.Collections.Generic;

namespace Lab5Banks
{
    public class Client
    {
        public string Name;
        public string Surname;
        public string Address;
        public string Passport;

        public List<BaseBankAccount> BankAccountList = new List<BaseBankAccount>();
        
        public Client(string name, string surname, string address = null, string passport = null)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Passport = passport;
        }

        public void ChangeInfo(string address = null, string passport = null)
        {
            Address = address;
            Passport = passport;
            foreach (BaseBankAccount account in BankAccountList)
            {
                account.CheckDoubtful();
            }
        }
    }
}