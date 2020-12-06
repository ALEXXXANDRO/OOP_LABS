namespace Lab5Banks.Commands
{
    public class TopUpCommand : BaseCommand
    {
        public TopUpCommand(BaseBankAccount bankAccount) : base(bankAccount){}

        public override void Execute(double cash)
        {
            Backup = _bankAccount.Balance;
            _bankAccount.TopUp(cash);
            _bankAccount.CommandHistory.Add(this);
        }

        public override void Undo()
        {
            _bankAccount.Balance = Backup;
        }
    }
}