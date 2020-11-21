using System.Collections.Generic;

namespace Lab4Backup
{
    public class Cleaner<T> where T : Algorithms
    {
        public List<Algorithms> AlgorithmsList  = new List<Algorithms>();
        public void RemovePoint(Backup backup, int extraPoints)
        {
            if (backup.RestorePointsList[extraPoints].IsIncrement == true)
            {
                throw new RemoveError("Инкрементальная точка не должна оставаться без базовой");
            }
            long removeSize = 0;
            for (int i = 0; i < extraPoints; i++)
            {
                removeSize += backup.RestorePointsList[i].PointSize;
            }
            backup.RestorePointsList.RemoveRange(0, extraPoints);
            backup.BackupSize -= removeSize;
        }

        public void addAlgoritm(T algorithm)
        {
            AlgorithmsList.Add(algorithm);
        }

        public int GetExtraPoint(bool isMax)
        {
            if(AlgorithmsList.Count == 0){throw new NoOneAlgorithm("Добавьте алгоритм для удаления");}
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