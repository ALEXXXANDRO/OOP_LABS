using System.Collections.Generic;

namespace Lab6Reports.BLL.DTO
{
    public class TeamReportDTO : BaseDTOEntities
    {
        public List<ReportDTO> ReportList { get; set; }
        public string Description { get; set; }
        public TeamReportDTO(string description, List<ReportDTO> reportList)
        {
            ReportList = reportList;
            Description = description;
        }
    }
}