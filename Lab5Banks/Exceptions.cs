using System;

namespace Lab5Banks
{
    public class DoubtfulAccount : Exception
        {
            public DoubtfulAccount() : base("Операция запрещена. Введите всю информацию о владельце")
            {
            }
        }
    public class NotEnoughMoney : Exception
        {
            public NotEnoughMoney() : base("Операция запрещена. Недостаточно средств на счете")
            {
            }
        }
    public class EndTimeError : Exception
        {
            public EndTimeError (string messange) : base(messange)
            {
            }
        }
    public class WrongAccount : Exception
        {
            public WrongAccount() : base("Такого счета не существует")
            {
            }
        }
}