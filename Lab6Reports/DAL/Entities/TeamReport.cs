using System.Collections.Generic;

namespace Lab6Reports.DAL
{
    public class TeamReportDAL : BaseEntities
    {
        private static int nextID = 1;
        public List<ReportDAL> ReportList { get; set; }
        public string Description { get; set; }
        public TeamReportDAL(string description, List<ReportDAL> reportList)
        {
            ID = nextID;
            nextID += 1;
            ReportList = reportList;
            Description = description;
        }
    }
}