using System.Collections.Generic;

namespace Lab6Reports.DAL
{
    public class EmployeeDAL : BaseEntities
    {
        private static int nextID = 1;
        public string Name { get; set;}
        public EmployeeDAL Leader { get; set;}
        public List<int> SubordinatesID { get; set;}
        
        public List<int> TaskList { get; set;}
        
        public EmployeeDAL(string name, List<int> subordinates, EmployeeDAL leader = null) 
        {
            ID = nextID;
            nextID += 1;
            Name = name;
            Leader = leader;
            SubordinatesID = subordinates;
            TaskList = new List<int>();
        }
        
        /// конструктор для дессeриализации
        public EmployeeDAL()
        {
        }
    }
}