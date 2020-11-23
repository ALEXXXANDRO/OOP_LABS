using System;
using System.Linq;

namespace Lab4Backup
{
    public class DateRemoveAlgorithm : IAlgorithms
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
            int extraPoints = ReduceBackup.RestorePointsList.Count( Point => Point.CreationTime < AllowedDatetime);
            
            return extraPoints;
        }
    }
}