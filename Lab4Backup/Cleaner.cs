using System.Collections.Generic;

namespace Lab4Backup
{
    public class Cleaner<T> where T : IAlgorithms
    {
        public List<IAlgorithms> AlgorithmsList  = new List<IAlgorithms>();

        public Cleaner(params T[] usedAlgorithms)
        {
            foreach (T algorithm in usedAlgorithms)
            {
                AlgorithmsList.Add(algorithm);
            }
            if(AlgorithmsList.Count == 0){throw new NoOneAlgorithm("Добавьте алгоритм для удаления");}
        } 
        public void RemovePoint(Backup backup, int extraPoints)
        {
            if (backup.RestorePointsList[extraPoints].IsIncrement == true)
            {
                throw new RemoveError("Инкрементальная точка не должна оставаться без базовой");
            }
            
            for (int i = 0; i < extraPoints; i++)
            {
                backup.BackupSize -= backup.RestorePointsList[i].PointSize;
            }
            backup.RestorePointsList.RemoveRange(0, extraPoints);
        }

        public void addAlgoritm(T algorithm)
        {
            AlgorithmsList.Add(algorithm);
        }

        public int GetExtraPoint(bool isMax)
        {
            int result = AlgorithmsList[0].GetExtraPoint();
            foreach (T algorithm in AlgorithmsList)
            {
                int extraPoint = algorithm.GetExtraPoint();
                if (isMax && extraPoint > result)
                {
                    result = extraPoint;
                }
                else if(!isMax && extraPoint < result)
                {
                    result = extraPoint;
                }
            }

            return result;
        }
    }
}