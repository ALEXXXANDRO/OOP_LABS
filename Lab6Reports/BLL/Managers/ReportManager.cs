using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


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

        public void AddTeamReport(DTO.TeamReport teamReport, DTO.Employee employee)
        {
            if(employee.Leader != null) {throw new ForbiddenEdit();}
            teamReport.ReportList.AddRange(GetSubordinatesReports(employee));
            _teamReportReposirory.Create(TeamReportToDALConverter(teamReport));
        }
        
        
        public void UpdateReport(DTO.Report report, int id, DTO.Employee employee) 
        { 
            if(!employee.ID.Equals(report.OwnerID)){throw new ForbiddenEdit();}
            if(!DateTime.Today.Equals(report.CreateTime) && !report.isDraft){throw new ItIsNotDraft();}
            DAL.Report DALReport = ToDALConverter(report);
            _reportReposirory.Update(DALReport,id);
        }
        
        public List<DTO.Report>  GetSubordinatesReports(DTO.Employee employee)
        {
            List<DTO.Report> DTOReportList  = new List<DTO.Report>();
            foreach (int employeeID in employee.SubordinatesID)
            {
                DTOReportList.AddRange(GetEmloyeesReports(_employeeManager.Get(employeeID)));
            }

            return DTOReportList;
        }

        public List<DTO.Report> GetEmloyeesReports(DTO.Employee employee)
        {
            List<DAL.Report> DALReportList = _reportReposirory.GetAll().FindAll(t => t.OwnerID.Equals(employee));
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
        }
    }
}