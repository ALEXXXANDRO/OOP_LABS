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
        public string[] FileList;
        public bool IsIncrement;


        public RestorePoint(bool isIncrement, long pointSize, DateTime creationTime, params string[] files)
        {
            this.ID = ID;
            this.IsIncrement = isIncrement;
            this.PointSize = pointSize;
            this.CreationTime = DateTime.Now;
            this.FileList = files;
        }
        
    }
}