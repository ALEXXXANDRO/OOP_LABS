using System.Collections.Generic;

namespace Lab6Reports.BLL.DTO
{
    public class TeamReport : BaseDTOEntities
    {
        public List<DTO.Report> ReportList { get; set; }
        public string Description { get; set; }
        public TeamReport(string description, List<DTO.Report> reportList)
        {
            ReportList = reportList;
            Description = description;
        }
    }
}