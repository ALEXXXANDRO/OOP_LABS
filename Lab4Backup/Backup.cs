using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4Backup
{
    public class Backup
    {
        private static int NextBackupID = 1;
        public int BackupID;
        public List<FileInfo> FileList;
        public List<RestorePoint> RestorePointsList;
        public long BackupSize = 0;
        
        
        public Backup()
        {
            this.BackupID = NextBackupID;
            NextBackupID += 1;
            this.FileList = new List<FileInfo>();
            this.RestorePointsList = new List<RestorePoint>();
        }

        public void CreateRestorePoint(bool isIncrement,long pointSize, List<FileInfo> files)
        {
            RestorePoint restorePoint = new RestorePoint(isIncrement,pointSize,DateTime.Now, files);
            RestorePointsList.Add(restorePoint);
            BackupSize += restorePoint.PointSize;
        }

        public void AddFiles(params string[] files)
        {
            foreach (string filepath in files)
            {
                if (!File.Exists(filepath)) throw new FileNotFoundException();
                if (IsFileInBackup(filepath))throw new FileAlreadyExists(filepath);
                var fileinfo = new FileInfo(filepath);
                this.FileList.Add(fileinfo);
            }
        }

        public void RemoveFiles(params string[] files)
        {
            foreach (string filepath in files)
            {
                if (!File.Exists(filepath)) throw new FileNotFoundException($"Не существует файла по указанному пути{0}",filepath);
                if(!IsFileInBackup(filepath)) throw new FileNotFoundException($"В бэкапе не существует файла с таким именем{0}", filepath);
                foreach (FileInfo file in FileList)
                {
                    if (file.FullName == filepath)
                        FileList.Remove(file);
                }
            }
        }

        public bool IsFileInBackup(string filepath)
        {
            bool result = FileList.Any(file => file.FullName == filepath);
            return result;
        }
        
    }
}