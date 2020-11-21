namespace Lab4Backup
{
    public class SizeRemoveAlgorithm : Algorithms
    {
        public Backup ReduceBackup;
        public long AllowedSize;
        
        public SizeRemoveAlgorithm(Backup reduceBackup, long allowedSize)
        {
            this.ReduceBackup = reduceBackup;
            this.AllowedSize = allowedSize;
        }
        
        public int GetExtraPoint()
        {
            int extraPoints = 0;
            long extraSize = ReduceBackup.BackupSize - AllowedSize;
            if (extraSize > 0)
            {
                long removedSize = 0;
                while(removedSize < extraSize)
                {
                    removedSize += ReduceBackup.RestorePointsList[extraPoints].PointSize;
                    extraPoints++;
                }
            }
            return extraPoints;
        }
    }
}