using System.Collections.Generic;

namespace Lab6Reports.BLL.DTO
{
    public class Employee
    {
        public int ID { get; set;}
        public string Name { get; set;}
        public DTO.Employee Leader { get; set;}
        public List<int> SubordinatesID { get; set;}
        public Employee(string name, DTO.Employee leader = null, List<int> subordinates = null)
        {
            Name = name;
            Leader = leader;
            SubordinatesID = subordinates;
        }
        
    }
}