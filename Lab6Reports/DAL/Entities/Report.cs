using System.Collections.Generic;

namespace Lab6Reports.DAL
{
    public class Report : BaseEntities
    {
        private static int nextID = 1;
        public List<Task> CompletedTasks { get; set;}
        public string Comment { get; set; }

        public bool Status { get; set; }

        public Report( List<Task> completedTasks, string comment, bool status)
        {
            ID = nextID;
            nextID += 1;
            CompletedTasks = completedTasks;
            Comment = comment;
            Status = status;
        }
        
        /// конструктор для дессeриализации
        public Report() { }
    }
}