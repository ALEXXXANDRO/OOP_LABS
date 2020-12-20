using System.Collections.Generic;

namespace Lab6Reports.DAL
{
    public class Employee : BaseEntities
    {
        private static int nextID = 1;
        public string Name { get; set;}
        public Employee Leader { get; set;}
        public List<int> SubordinatesID { get; set;}
        
        public List<Task> TaskList { get; set;}
        
        public Employee(string name,  Employee leader = null, List<int> subordinates = null) 
        {
            ID = nextID;
            nextID += 1;
            Name = name;
            Leader = leader;
            SubordinatesID = subordinates;
        }
        
        /// конструктор для дессeриализации
        public Employee()
        {
        }
    }
}