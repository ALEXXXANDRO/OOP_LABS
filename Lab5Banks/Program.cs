using System;
using Lab5Banks.Commands;
using Lab5Banks.Creators;

namespace Lab5Banks
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeMachine.timeMachine.ChangeDate(366);
            Console.WriteLine(TimeMachine.timeMachine.MyTime);
        }
    }
}