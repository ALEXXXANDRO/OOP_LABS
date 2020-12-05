namespace Lab5Banks.Creators
{
    public class DebitAccountCreator : IAccountCreator
    {
        public BaseBankAccount CreateAccount(Client owner, Bank bank, double balance)
        {
            return new DebitAccount(owner, bank, balance);
        }
    }
}