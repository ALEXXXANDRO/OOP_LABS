using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Lab6Reports.DAL;


namespace Lab6Reports.BLL
{
    public class ReportManager
    {
        DAL.Reposirory<DAL.Report> _reportReposirory;
        DAL.Reposirory<DAL.TeamReport> _teamReportReposirory;
        TaskManager _taskManager;
        EmployeeManager _employeeManager;
        
        public DAL.Report ToDALConverter(DTO.Report report)
        {
            var DALReport = new DAL.Report(report.Comment, report.OwnerID);
            DALReport.isDraft = report.isDraft;
            DALReport.CreateTime = report.CreateTime;
            DALReport.CompletedTasksID = report.CompletedTasksID;
            return DALReport;
        }
        public DTO.Report ToDTOConverter(DAL.Report report)
        {
            var DTOReport = new DTO.Report(report.Comment,report.OwnerID);
            DTOReport.ID = report.ID;
            DTOReport.isDraft = report.isDraft;
            DTOReport.CreateTime = report.CreateTime;
            DTOReport.CompletedTasksID = report.CompletedTasksID;
            return DTOReport;
        }
        
        public DTO.TeamReport TeamReportToDTOConverter(DAL.TeamReport teamReport)
        {
            var reports = new List<DTO.Report>();
            foreach ( DAL.Report report in teamReport.ReportList)
            {
                reports.Add(ToDTOConverter(report));
            }
            var DTOTeamReport = new DTO.TeamReport(teamReport.Description,reports);
            DTOTeamReport.ID = teamReport.ID;
            return DTOTeamReport;
        }
        
        public DAL.TeamReport TeamReportToDALConverter(DTO.TeamReport teamReport)
        {
            var reports = new List<DAL.Report>();
            foreach ( DTO.Report report in teamReport.ReportList)
            {
                reports.Add(ToDALConverter(report));
            }
            var DALTeamReport = new DAL.TeamReport(teamReport.Description, reports);
            return DALTeamReport;
        }

        public void AddDailyReport(DTO.Report report)
        {
            var DALReport = ToDALConverter(report);
            DALReport.isDraft = false;
            _reportReposirory.Create(DALReport);
            report.ID = DALReport.ID;
            report.isDraft = false;
        }
            
        public void AddSprintReport(DTO.Report report)
        {
            var DALReport = ToDALConverter(report);
            _reportReposirory.Create(DALReport);
            report.ID = DALReport.ID;
        }

        public void AddTeamReport(DTO.TeamReport teamReport, int employeeID)
        {
            if(_employeeManager.Get(employeeID).Leader != null) {throw new ForbiddenEdit();}
            teamReport.ReportList.AddRange(GetSubordinatesReports(employeeID));
            _teamReportReposirory.Create(TeamReportToDALConverter(teamReport));
        }
        public DTO.TeamReport GetTeamReport(int id)
        {
            DAL.TeamReport DALTeamReport = _teamReportReposirory.Get(id);
            var t = TeamReportToDTOConverter(DALTeamReport);
            return t;
        }
        public void UpdateReport(DTO.Report report, int id, int employeeID) 
        { 
            if(!employeeID.Equals(report.OwnerID)){throw new ForbiddenEdit();}
            if(!DateTime.Today.Equals(report.CreateTime) && !report.isDraft){throw new ItIsNotDraft();}
            DAL.Report DALReport = ToDALConverter(report);
            _reportReposirory.Update(DALReport,id);
        }
        
        public List<DTO.Report>  GetSubordinatesReports(int employeeID)
        {
            List<DTO.Report> DTOReportList  = new List<DTO.Report>();
            foreach (int subordinatesID in _employeeManager.Get(employeeID).SubordinatesID)
            {
                DTOReportList.AddRange(GetEmloyeesReports(subordinatesID));
            }

            return DTOReportList;
        }

        public List<DTO.Report> GetEmloyeesReports(int employeeID)
        {
            List<DAL.Report> DALReportList = _reportReposirory.GetAll().FindAll(t => t.OwnerID.Equals(employeeID));
            List<DTO.Report> DTOReportList  = new List<DTO.Report>();
            foreach (var report in DALReportList)
            {
                var t = ToDTOConverter(report);
                DTOReportList.Add(t);
            }
            return DTOReportList;
        }
        
        public ReportManager()
        {
            _employeeManager = new EmployeeManager();
            _taskManager = new TaskManager();
            _reportReposirory = new DAL.Reposirory<DAL.Report>("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\Reports.json");
            _teamReportReposirory = new DAL.Reposirory<TeamReport>("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\TeamReports.json");
        }
    }
}