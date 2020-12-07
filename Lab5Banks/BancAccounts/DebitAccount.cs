using System;

namespace Lab5Banks
{
    public class DebitAccount : AccountsWithProcents
    {
        public DebitAccount(Client owner, Bank bank,double balance) : base(owner, bank,balance) {}
    }
}