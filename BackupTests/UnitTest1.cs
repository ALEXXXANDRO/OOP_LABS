using Lab4Backup;
using NUnit.Framework;

namespace BackupTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            BackupManager manager = new BackupManager();
            Backup backup1 = new Backup();
            manager.addBackup(backup1);
            
            backup1.AddFiles("D:\\учебники\\универ английский\\Empower_A2_Student's Book.pdf");
            backup1.AddFiles("D:\\учебники\\discr_math.pdf");
            Assert.AreEqual(2, backup1.FileList.Count);
            
            manager.SplitCopyАlgorithm(backup1, false);
            
            AmountRemoveAlgorithm alg1 = new AmountRemoveAlgorithm(backup1, 1);
            Cleaner<IAlgorithms> cleaner = new Cleaner<IAlgorithms>(alg1);
           
            cleaner.RemovePoint(backup1,alg1.GetExtraPoint());
            Assert.AreEqual(1, backup1.RestorePointsList.Count);
        }

        [Test]
        public void Test2()
        {
            BackupManager manager = new BackupManager();
            Backup backup1 = new Backup();
            manager.addBackup(backup1);
            
            backup1.AddFiles("D:\\10mb-file.txt");
            backup1.AddFiles("D:\\10mb-file2.txt");

            
            manager.SplitCopyАlgorithm(backup1, false);
            manager.SplitCopyАlgorithm(backup1, false);
            Assert.AreEqual(2, backup1.RestorePointsList.Count);
            Assert.AreEqual(4e+7,backup1.BackupSize);
           
            SizeRemoveAlgorithm alg1 = new SizeRemoveAlgorithm(backup1,(long)3e+7);
            Cleaner<IAlgorithms> cleaner = new Cleaner<IAlgorithms>(alg1);
            cleaner.RemovePoint(backup1,alg1.GetExtraPoint());
            
            Assert.AreEqual(2e+7,backup1.BackupSize);
            Assert.AreEqual(1, backup1.RestorePointsList.Count);
        }

        [Test]
        public void Test3Hybrid()
        {
            BackupManager manager = new BackupManager();
            Backup backup1 = new Backup();
            manager.addBackup(backup1);
            
            backup1.AddFiles("D:\\10mb-file.txt");
            backup1.AddFiles("D:\\10mb-file2.txt");
            backup1.AddFiles("D:\\учебники\\универ английский\\Empower_A2_Student's Book.pdf");

            manager.SplitCopyАlgorithm(backup1, false);
            manager.SplitCopyАlgorithm(backup1, false);
            manager.SplitCopyАlgorithm(backup1, false);
            
            SizeRemoveAlgorithm alg1 = new SizeRemoveAlgorithm(backup1,(long)1.5e+7);
            AmountRemoveAlgorithm alg2 = new AmountRemoveAlgorithm(backup1, 1);
            
            Cleaner<IAlgorithms> cleaner = new Cleaner<IAlgorithms>(alg1,alg2);
            cleaner.RemovePoint(backup1,cleaner.GetExtraPoint(false));
            Assert.AreEqual(1, backup1.RestorePointsList.Count);
        }

        [Test]
        public void Test4IncrementPoint()
        {
            BackupManager manager = new BackupManager();
            Backup backup1 = new Backup();
            manager.addBackup(backup1);
            
            backup1.AddFiles("D:\\10mb-file.txt");
            manager.SplitCopyАlgorithm(backup1, false);
            Assert.AreEqual(1e+7,backup1.RestorePointsList[0].PointSize);
            
            backup1.AddFiles("D:\\10mb-file2.txt");
            manager.SplitCopyАlgorithm(backup1,true); 
            Assert.AreEqual(1e+7,backup1.RestorePointsList[1].PointSize);
            Assert.AreEqual(2e+7,backup1.BackupSize);
        }
    }
}