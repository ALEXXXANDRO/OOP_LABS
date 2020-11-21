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
        public List<string> FileList;
        public List<RestorePoint> RestorePointsList;
        public long BackupSize = 0;
        
        
        public Backup()
        {
            this.BackupID = NextBackupID;
            NextBackupID += 1;
            this.FileList = new List<string>();
            this.RestorePointsList = new List<RestorePoint>();
            BackupManager.manager.BackupList.Add(this);
        }

        public void CreateRestorePoint(bool isIncrement,long pointSize, params string[] files)
        {
            RestorePoint restorePoint = new RestorePoint(isIncrement,pointSize,DateTime.Now,files);
            RestorePointsList.Add(restorePoint);
            BackupSize += restorePoint.PointSize;
        }

        public void AddFiles(params string[] files)
        {
            foreach (string filepath in files)
            {
                if (!File.Exists(filepath)) throw new FileNotFoundException("Не существует файла по указанному пути " + filepath);
                if(FileList.Contains(filepath)) throw new FileAlreadyExists("Этот файл уже хранится в бэкапе " + filepath);
                FileList.Add(filepath);
            }
        }

        public void RemoveFiles(params string[] files)
        {
            foreach (string filepath in files)
            {
                if (!File.Exists(filepath)) throw new FileNotFoundException("Не существует файла по указанному пути " + filepath);
                if(!FileList.Contains(filepath)) throw new NoSuchFile("В бэкапе не существует файла с таким именем" + filepath );
                FileList.Remove(filepath);
            }
        }
        
        
        
    }
}