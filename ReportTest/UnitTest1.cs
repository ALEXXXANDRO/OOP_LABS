using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab6Reports;
using Lab6Reports.BLL;
using Lab6Reports.BLL.DTO;
using NUnit.Framework;

namespace ReportTest
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var emloyee = new Lab6Reports.BLL.DTO.Employee("Вася", new List<int>());
            var emloyee2 = new Lab6Reports.BLL.DTO.Employee("Коля", new List<int>(),emloyee);
            
            var task1 = new Lab6Reports.BLL.DTO.Task("Some Problem", "1", TaskState.Open,2);
            var task2 = new Lab6Reports.BLL.DTO.Task("KEK", "1", TaskState.Open, 2);
            
            var taskManager = new TaskManager();
            var emploeeManager = new EmployeeManager();
            var reportManager = new ReportManager();
            
            emploeeManager.Add(emloyee);
            emploeeManager.Add(emloyee2);
            
            taskManager.Add(task1, 1);
            taskManager.Add(task2, 1);
            
            Assert.AreEqual("Some Problem",taskManager.Get(1).Name );
            Assert.AreEqual("KEK",taskManager.Get(2).Name );
            
            var task3 = new Lab6Reports.BLL.DTO.Task("KEK", "1", TaskState.Resolved, 2);
            taskManager.Update(task3, 2,1);
            Assert.AreEqual("KEK", taskManager.GetTaskByEditor(2).First().Name);
            Assert.AreEqual(TaskState.Resolved,taskManager.Get(1).State );
            
            Assert.AreEqual(1,taskManager.GetResolvedTasks(2).Count);
            Assert.AreEqual(1, taskManager.GetResolvedDailyTasks(2).Count);
            
            Assert.AreEqual(2, taskManager.GetTaskByOwner(2).Count);
            Assert.AreEqual(2, taskManager.GetSubordinatesTasks(1).Count);
            
            Assert.AreEqual(2, taskManager.GetTaskByCreateTime(DateTime.Today).Count);

            DateTime testDate = taskManager.Get(2).Logger.Last().First;
            Assert.AreEqual(1, taskManager.GetTaskByChangeTime(testDate).Count);
            
            
            
            
            
            
            
            
            
            var report1 = new Lab6Reports.BLL.DTO.Report("Nice LAB awesome Tasks", 2);
            reportManager.AddDailyReport(report1);
            
            Assert.AreEqual("Nice LAB awesome Tasks", reportManager.GetEmloyeesReports(2).First().Comment);
            Assert.AreEqual(1, reportManager.GetSubordinatesReports(1).Count);
            var report2 = new Lab6Reports.BLL.DTO.Report("Oh men...", 2);
            reportManager.UpdateReport(report2,1,2);
            Assert.AreEqual("Oh men...", reportManager.GetEmloyeesReports(2).First().Comment);
            
            var teamReport = new Lab6Reports.BLL.DTO.TeamReport("Заходят как то в бар...", new List<Report>());
            reportManager.AddTeamReport(teamReport,1);
            Assert.AreEqual("Oh men...", reportManager.GetTeamReport(1).ReportList.First().Comment);
            
            File.Delete("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\Task.json");
            File.Delete("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\Employee.json");
            File.Delete("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\Reports.json");
            File.Delete("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\TeamReports.json");
        }
    }
}