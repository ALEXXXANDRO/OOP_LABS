using System;
using System.Collections.Generic;

namespace Lab6Reports.BLL.DTO
{
    public class ReportDTO : BaseDTOEntities
    {
        public DateTime CreateTime { get; set; }
        public List<int> CompletedTasksID { get; set;}
        public string Comment { get; set; }
        
        public int OwnerID { get; set;}
        public bool isDraft { get; set; }

        public ReportDTO(string comment, int ownerID)
        {
            Comment = comment;
            isDraft = true;
            OwnerID = ownerID;
            CreateTime = DateTime.Today;
        }
        
        
    }
}