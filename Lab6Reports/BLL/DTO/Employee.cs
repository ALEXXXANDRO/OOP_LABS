using System.Collections.Generic;

namespace Lab6Reports.BLL.DTO
{
    public class Employee
    {
        public int ID { get; set;}
        public string Name { get; set;}
        public DTO.Employee Leader { get; set;}
        public List<DTO.Employee> Subordinates { get; set;}
        
        public Employee(int id, string name, DTO.Employee leader, List<DTO.Employee> subordinates)
        {
            ID = id;
            Name = name;
            Leader = leader;
            Subordinates = subordinates;
        }
        
    }
}