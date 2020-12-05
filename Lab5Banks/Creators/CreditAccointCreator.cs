namespace Lab5Banks.Creators
{
    public class CreditAccointCreator : IAccountCreator
    {
        public BaseBankAccount CreateAccount(Client owner, Bank bank, double balance)
        {
            return new CreditAccount(owner, bank, balance);
        }
    }
}