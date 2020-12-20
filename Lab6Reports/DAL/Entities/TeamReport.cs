using System.Collections.Generic;

namespace Lab6Reports.DAL
{
    public class TeamReport : BaseEntities
    {
        public List<DAL.Report> ReportList { get; set; }
        public string Description { get; set; }
        public TeamReport(string description, List<DAL.Report> reportList)
        {
            ReportList = reportList;
            Description = description;
        }
    }
}