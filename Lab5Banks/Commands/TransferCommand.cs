namespace Lab5Banks.Commands
{
    public class TransferCommand : BaseCommand
    {
        protected BaseBankAccount _bankAccountTopUp;

        public TransferCommand(BaseBankAccount bankAccount1, BaseBankAccount bankAccountTopUp) : base(bankAccount1)
        {
            _bankAccountTopUp = bankAccountTopUp;
        }

        public override void Execute(double cash)
        {
            Backup = cash;
            _bankAccount.Transfer(cash,_bankAccountTopUp);
            _bankAccount.CommandHistory.Add(this);
        }

        public override void Undo()
        {
            _bankAccountTopUp.Transfer(Backup, _bankAccount);
        }
    }
}