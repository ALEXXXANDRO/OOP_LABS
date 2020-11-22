using System;
using System.Linq;

namespace Lab4Backup
{
    class Program
    {
        static void Main(string[] args)
        {
            BackupManager manager = new BackupManager();
            Backup backup1 = new Backup();
            manager.addBackup(backup1);
            
            backup1.AddFiles("D:\\10mb-file.txt");
            backup1.AddFiles("D:\\10mb-file.txt");
        }
    }
}