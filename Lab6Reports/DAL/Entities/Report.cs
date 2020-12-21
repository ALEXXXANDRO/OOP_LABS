using System;
using System.Collections.Generic;

namespace Lab6Reports.DAL
{
    public class ReportDAL : BaseEntities
    {
        private static int nextID = 1;

        public DateTime CreateTime { get; set; }
        public List<int> CompletedTasksID { get; set;}
        public string Comment { get; set; }
        public int OwnerID { get; set;}
        public bool isDraft { get; set; }

        public ReportDAL( string comment, int ownerID)
        {
            ID = nextID;
            nextID += 1;
            Comment = comment;
            OwnerID = ownerID;
            isDraft = true;
            CreateTime = DateTime.Today;
        }
        
        /// конструктор для дессeриализации
        public ReportDAL() { }
    }
}