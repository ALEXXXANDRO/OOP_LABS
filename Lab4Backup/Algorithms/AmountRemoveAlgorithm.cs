namespace Lab4Backup
{
    public class AmountRemoveAlgorithm : Algorithms
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
            if (extraPoints > 0)
            {
                return extraPoints;
            }
            else
            {
                return 0;
            }
        }
        
    }
}