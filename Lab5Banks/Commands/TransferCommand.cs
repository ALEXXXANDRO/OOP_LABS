namespace Lab5Banks.Commands
{
    public class TransferCommand : BaseCommand
    {
        protected double Backup2;
        protected BaseBankAccount _bankAccountTopUp;

        public TransferCommand(BaseBankAccount bankAccount1, BaseBankAccount bankAccountTopUp) : base(bankAccount1)
        {
            _bankAccountTopUp = bankAccountTopUp;
        }

        public override void Execute(double cash)
        {
            Backup = _bankAccount.Balance;
            Backup2 = _bankAccountTopUp.Balance;
            _bankAccount.Transfer(cash,_bankAccountTopUp);
            _bankAccount.CommandHistory.Add(this);
        }

        public override void Undo()
        {
            _bankAccount.Balance = Backup;
            _bankAccountTopUp.Balance = Backup2;
        }
    }
}