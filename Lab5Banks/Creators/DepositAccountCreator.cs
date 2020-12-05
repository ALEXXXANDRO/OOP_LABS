namespace Lab5Banks.Creators
{
    public class DepositAccountCreator : IAccountCreator
    {
        public BaseBankAccount CreateAccount(Client owner, Bank bank, double balance)
        {
            var account = new DepositAccount(owner, bank, balance);
            bank.SetProcents(account);
            return account;
        }
    }
}