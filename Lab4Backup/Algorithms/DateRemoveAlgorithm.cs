using System;

namespace Lab4Backup
{
    public class DateRemoveAlgorithm : Algorithms
    {
        public Backup ReduceBackup;
        public DateTime AllowedDatetime;
        
        public DateRemoveAlgorithm(Backup reduceBackup, DateTime allowedDatetime)
        {
            this.ReduceBackup = reduceBackup;
            this.AllowedDatetime =  allowedDatetime;
        }
        public int GetExtraPoint()
        {
            int extraPoints = 0;
            for (int i = 0; i < ReduceBackup.RestorePointsList.Count; i++)
            {
                if (ReduceBackup.RestorePointsList[i].CreationTime < AllowedDatetime)
                {
                    extraPoints += 1;
                }
            }

            return extraPoints;
        }
    }
}