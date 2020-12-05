using System.Collections.Generic;

namespace Lab5Banks
{
    public class Client
    {
        private string Name;
        private string Surname;
        private string Address;
        private string Passport;

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
            CheckDoubtful();
        }

        public void CheckDoubtful()
        {
            foreach (BaseBankAccount account in BankAccountList)
            {
                account.isDoubtful = (Passport == null && Address == null);
            }
        }
        
    }
}