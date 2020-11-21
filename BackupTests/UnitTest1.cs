using Lab4Backup;
using NUnit.Framework;

namespace BackupTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Backup backup1 = new Backup();
            backup1.AddFiles("D:\\учебники\\универ английский\\Empower_A2_Student's Book.pdf");
            backup1.AddFiles("D:\\учебники\\discr_math.pdf");
            Assert.AreEqual(2, backup1.FileList.Count);
            
            BackupManager.manager.SplitCopyАlgorithm(backup1, false,
                "D:\\учебники\\универ английский\\Empower_A2_Student's Book.pdf");
            
            Cleaner<Algorithms> cleaner = new Cleaner<Algorithms>();
            AmountRemoveAlgorithm alg1 = new AmountRemoveAlgorithm(backup1, 1);
            cleaner.addAlgoritm(alg1);
            cleaner.RemovePoint(backup1,alg1.GetExtraPoint());
            Assert.AreEqual(1, backup1.RestorePointsList.Count);
        }

        [Test]
        public void Test2()
        {
            Backup backup1 = new Backup();
            backup1.AddFiles("D:\\10mb-file.txt");
            backup1.AddFiles("D:\\10mb-file2.txt");

            BackupManager.manager.SplitCopyАlgorithm(backup1, false, "D:\\10mb-file.txt");
            BackupManager.manager.SplitCopyАlgorithm(backup1, false, "D:\\10mb-file2.txt");
            Assert.AreEqual(2, backup1.RestorePointsList.Count);
            Assert.AreEqual(2e+7,backup1.BackupSize);
           
            Cleaner<Algorithms> cleaner = new Cleaner<Algorithms>();
            SizeRemoveAlgorithm alg1 = new SizeRemoveAlgorithm(backup1,(long)1.5e+7);
            cleaner.addAlgoritm(alg1);
            cleaner.RemovePoint(backup1,alg1.GetExtraPoint());
            
            Assert.AreEqual(1e+7,backup1.BackupSize);
            Assert.AreEqual(1, backup1.RestorePointsList.Count);
        }

        [Test]
        public void Test3Hybrid()
        {
            Backup backup1 = new Backup();
            backup1.AddFiles("D:\\10mb-file.txt");
            backup1.AddFiles("D:\\10mb-file2.txt");
            backup1.AddFiles("D:\\учебники\\универ английский\\Empower_A2_Student's Book.pdf");

            BackupManager.manager.SplitCopyАlgorithm(backup1, false, "D:\\10mb-file.txt");
            BackupManager.manager.SplitCopyАlgorithm(backup1, false, "D:\\10mb-file2.txt");
            BackupManager.manager.SplitCopyАlgorithm(backup1, false, "D:\\учебники\\универ английский\\Empower_A2_Student's Book.pdf");
            
            Cleaner<Algorithms> cleaner = new Cleaner<Algorithms>();
            SizeRemoveAlgorithm alg1 = new SizeRemoveAlgorithm(backup1,(long)1.5e+7);
            AmountRemoveAlgorithm alg2 = new AmountRemoveAlgorithm(backup1, 1);
            cleaner.addAlgoritm(alg1);
            cleaner.addAlgoritm(alg2);
            cleaner.RemovePoint(backup1,cleaner.GetExtraPoint(false));
            Assert.AreEqual(1, backup1.RestorePointsList.Count);
        }

        [Test]
        public void Test4IncrementPoint()
        {
            Backup backup1 = new Backup();
            backup1.AddFiles("D:\\10mb-file.txt");
            backup1.AddFiles("D:\\10mb-file2.txt");

            BackupManager.manager.SplitCopyАlgorithm(backup1, false, "D:\\10mb-file.txt");
            BackupManager.manager.SplitCopyАlgorithm(backup1,true, "D:\\10mb-file2.txt"); ;
            Assert.AreEqual(1e+7,backup1.RestorePointsList[1].PointSize);
        }
    }
}