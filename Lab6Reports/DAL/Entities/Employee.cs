using System.Collections.Generic;

namespace Lab6Reports.DAL
{
    public class Employee : BaseEntities
    {
        private static int nextID = 1;
        public string Name { get; set;}
        public Employee Leader { get; set;}
        public List<Employee> Subordinates { get; set;}
        
        public Employee(string name, List<Employee> subordinates = null,  Employee leader = null) 
        {
            ID = nextID;
            nextID += 1;
            Name = name;
            Leader = leader;
            Subordinates = subordinates;
        }
        
        /// конструктор для дессeриализации
        public Employee()
        {
        }
    }
}