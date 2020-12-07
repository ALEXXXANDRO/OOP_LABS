namespace Lab5Banks.Commands
{
    public class WithdrawCommand : BaseCommand
    {
        public WithdrawCommand(BaseBankAccount bankAccount) : base(bankAccount){}
        public override void Execute(double cash)
        {
            Backup = _bankAccount.Balance;
            _bankAccount.Withdraw(cash);
            _bankAccount.CommandHistory.Add(this);
        }

        public override void Undo()
        {
            _bankAccount.Balance = Backup;
        }
    }
}