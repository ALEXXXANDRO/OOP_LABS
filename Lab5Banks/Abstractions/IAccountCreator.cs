namespace Lab5Banks
{
    public interface IAccountCreator
    {
        BaseBankAccount CreateAccount(Client owner, Bank bank, double balance);
    }
}