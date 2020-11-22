using System;
using System.Collections.Generic;
using System.IO;


namespace Lab4Backup
{
    public class RestorePoint
    {
        public int ID;
        public long PointSize;
        public DateTime CreationTime;
        public List<FileInfo> FileList;
        public bool IsIncrement;
        

        public RestorePoint(bool isIncrement, long pointSize, DateTime creationTime, List<FileInfo> fileList)
        {
            this.ID = ID;
            this.IsIncrement = isIncrement;
            this.PointSize = pointSize;
            this.CreationTime = DateTime.Now;
            FileList = new List<FileInfo>(fileList);
            
        }
        
    }
}