using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4Backup
{
    public class BackupManager 
    {
        public static BackupManager manager = new BackupManager();
        public List<Backup> BackupList = new List<Backup>();


        public long GetAddedPointSize(Backup backup, bool isIncrement, params string[] files)
        {
            long pointSize = 0;
            foreach (string filepath in files)
            {
                var fileinfo = new FileInfo(filepath);
                if(!backup.IsFileInBackup(filepath))
                {
                    throw new FileNotFoundException($"В бэкапе не существует файла с таким именем{0}", filepath);
                }
                if(!isIncrement || !backup.RestorePointsList.Last().FileList.Contains(filepath))
                    pointSize += fileinfo.Length;
    
            }

            return pointSize;
        }
        public void SplitCopyАlgorithm(Backup backup, bool isIncrement, params string[] files)
        {
            long pointSize = GetAddedPointSize(backup, isIncrement, files);
            backup.CreateRestorePoint(isIncrement,pointSize, files);
        }

        public void JointCopyAlgorithm(Backup backup, bool isIncrement, string dirName,params string[] files)
        {
            long pointSize = GetAddedPointSize(backup, isIncrement, files);
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\SomeDir");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory($@"{dirName}");
            backup.CreateRestorePoint(isIncrement,pointSize, $@"C:\SomeDir\{dirName}");
        }

    }
}
