using System.Collections.Generic;

namespace Lab6Reports.DAL
{
    public class TeamReport : BaseEntities
    {
        private static int nextID = 1;
        public List<DAL.Report> ReportList { get; set; }
        public string Description { get; set; }
        public TeamReport(string description, List<DAL.Report> reportList)
        {
            ID = nextID;
            nextID += 1;
            ReportList = reportList;
            Description = description;
        }
    }
}