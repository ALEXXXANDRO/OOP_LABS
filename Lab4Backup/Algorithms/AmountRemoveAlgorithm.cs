using System;
using System.Text.RegularExpressions;

namespace Lab4Backup
{
    public class AmountRemoveAlgorithm : IAlgorithms
    {
        public Backup ReduceBackup;
        public int AllowedAmount;
        
        public AmountRemoveAlgorithm(Backup reduceBackup, int allowedAmount)
        {
            this.ReduceBackup = reduceBackup;
            this.AllowedAmount =  allowedAmount;
        }
        public int GetExtraPoint()
        {
            int extraPoints = ReduceBackup.RestorePointsList.Count - AllowedAmount;
            return Math.Max(0, extraPoints);
        }
        
    }
}