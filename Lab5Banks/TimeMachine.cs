using System;
using System.Reflection;
using Lab5Banks.Commands;

namespace Lab5Banks
{
    public class TimeMachine
    {
        public static TimeMachine timeMachine = new TimeMachine();
        public DateTime MyTime;

        public TimeMachine()
        {
            MyTime = DateTime.Now;
        }
        public void ChangeDate(int Days)
        {
            MyTime = MyTime.AddDays(Days);
        }
    }
}