using System.Collections.Generic;

namespace Lab6Reports.BLL.DTO
{
    public class Employee
    {
        public int ID { get; set;}
        public string Name { get; set;}
        public DTO.Employee Leader { get; set;}
        public List<int> SubordinatesID { get; set;}
        public List<int> TaskList { get; set;}
        public Employee(string name, List<int> subordinates, DTO.Employee leader = null)
        {
            Name = name;
            Leader = leader;
            SubordinatesID = subordinates;
            TaskList = new List<int>();
        }
        
    }
}