using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Lab6Reports.BLL.DTO;
using Lab6Reports.DAL;


namespace Lab6Reports.BLL
{
    public class ReportManager
    {
        Reposirory<ReportDAL> _reportReposirory;
        Reposirory<TeamReportDAL> _teamReportReposirory;
        TaskManager _taskManager;
        EmployeeManager _employeeManager;
        
        public ReportDAL ToDALConverter(ReportDTO report)
        {
            var DALReport = new ReportDAL(report.Comment, report.OwnerID);
            DALReport.isDraft = report.isDraft;
            DALReport.CreateTime = report.CreateTime;
            DALReport.CompletedTasksID = report.CompletedTasksID;
            return DALReport;
        }
        public ReportDTO ToDTOConverter(ReportDAL report)
        {
            var DTOReport = new ReportDTO(report.Comment,report.OwnerID);
            DTOReport.ID = report.ID;
            DTOReport.isDraft = report.isDraft;
            DTOReport.CreateTime = report.CreateTime;
            DTOReport.CompletedTasksID = report.CompletedTasksID;
            return DTOReport;
        }
        
        public TeamReportDTO TeamReportToDTOConverter(TeamReportDAL teamReport)
        {
            var reports = new List<ReportDTO>();
            foreach ( ReportDAL report in teamReport.ReportList)
            {
                reports.Add(ToDTOConverter(report));
            }
            var DTOTeamReport = new TeamReportDTO(teamReport.Description,reports);
            DTOTeamReport.ID = teamReport.ID;
            return DTOTeamReport;
        }
        
        public TeamReportDAL TeamReportToDALConverter(TeamReportDTO teamReport)
        {
            var reports = new List<ReportDAL>();
            foreach ( ReportDTO report in teamReport.ReportList)
            {
                reports.Add(ToDALConverter(report));
            }
            var DALTeamReport = new TeamReportDAL(teamReport.Description, reports);
            return DALTeamReport;
        }

        public void AddDailyReport(ReportDTO report)
        {
            var DALReport = ToDALConverter(report);
            DALReport.isDraft = false;
            _reportReposirory.Create(DALReport);
            report.ID = DALReport.ID;
            report.isDraft = false;
        }
            
        public void AddSprintReport(ReportDTO report)
        {
            var DALReport = ToDALConverter(report);
            _reportReposirory.Create(DALReport);
            report.ID = DALReport.ID;
        }

        public void AddTeamReport(TeamReportDTO teamReport, int employeeID)
        {
            if(_employeeManager.Get(employeeID).Leader != null) {throw new ForbiddenEdit();}
            teamReport.ReportList.AddRange(GetSubordinatesReports(employeeID));
            _teamReportReposirory.Create(TeamReportToDALConverter(teamReport));
        }
        public TeamReportDTO GetTeamReport(int id)
        {
            TeamReportDAL DALTeamReport = _teamReportReposirory.Get(id);
            var t = TeamReportToDTOConverter(DALTeamReport);
            return t;
        }
        public void UpdateReport(ReportDTO report, int id, int employeeID) 
        { 
            if(!employeeID.Equals(report.OwnerID)){throw new ForbiddenEdit();}
            if(!DateTime.Today.Equals(report.CreateTime) && !report.isDraft){throw new ItIsNotDraft();}
            ReportDAL DALReport = ToDALConverter(report);
            _reportReposirory.Update(DALReport,id);
        }
        
        public List<ReportDTO>  GetSubordinatesReports(int employeeID)
        {
            List<ReportDTO> DTOReportList  = new List<ReportDTO>();
            foreach (int subordinatesID in _employeeManager.Get(employeeID).SubordinatesID)
            {
                DTOReportList.AddRange(GetEmloyeesReports(subordinatesID));
            }

            return DTOReportList;
        }

        public List<ReportDTO> GetEmloyeesReports(int employeeID)
        {
            List<ReportDAL> DALReportList = _reportReposirory.GetAll().FindAll(t => t.OwnerID.Equals(employeeID));
            List<ReportDTO> DTOReportList  = new List<ReportDTO>();
            foreach (var report in DALReportList)
            {
                var t = ToDTOConverter(report);
                DTOReportList.Add(t);
            }
            return DTOReportList;
        }
        
        public ReportManager(string taskPath, string employeePath, string reportPath, string teamReportPath)
        {
            _employeeManager = new EmployeeManager(employeePath);
            _taskManager = new TaskManager(taskPath,employeePath);
            _reportReposirory = new DAL.Reposirory<ReportDAL>(reportPath);
            _teamReportReposirory = new DAL.Reposirory<TeamReportDAL>(teamReportPath);
        }
    }
}