using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4Backup
{
    public class BackupManager 
    {
        public List<Backup> BackupList = new List<Backup>();
        
        public void addBackup(Backup backup)
        {
            BackupList.Add(backup);
        } 
        public long GetAddedPointSize(Backup backup, bool isIncrement)
        {
            long pointSize = 0;
            foreach (FileInfo file in backup.FileList)
            {
                if(!isIncrement) 
                    pointSize += file.Length;
                else if(!backup.RestorePointsList.Last().FileList.Contains(file))
                pointSize+= file.Length;
            }
            return pointSize;
        }
        
        public void SplitCopyАlgorithm(Backup backup, bool isIncrement)
        {
            long pointSize = GetAddedPointSize(backup, isIncrement);
            backup.CreateRestorePoint(isIncrement,pointSize, backup.FileList);
        }

        public void JointCopyAlgorithm(Backup backup, bool isIncrement, string dirName)
        {
            long pointSize = GetAddedPointSize(backup, isIncrement);
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\SomeDir");
            dirInfo.CreateSubdirectory($@"{dirName}");
            var fileinfo = new FileInfo($@"C:\SomeDir\{dirName}");
            List<FileInfo> archive = new List<FileInfo>();
            archive.Add(fileinfo);
            backup.CreateRestorePoint(isIncrement,pointSize,archive );
        }

    }
}
