namespace Lab5Banks
{
    public abstract class BaseCommand
    {
        protected double Backup;
        protected BaseBankAccount _bankAccount;

        public BaseCommand(BaseBankAccount bankAccount)
        {
            _bankAccount = bankAccount;
        }
        public abstract void Execute(double cash);
        public abstract void Undo();
    }
}