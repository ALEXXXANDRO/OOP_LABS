using System.Collections.Generic;

namespace Lab6Reports.BLL.DTO
{
    public class EmployeeDTO : BaseDTOEntities
    {
        public string Name { get; set;}
        public EmployeeDTO Leader { get; set;}
        public List<int> SubordinatesID { get; set;}
        public List<int> TaskList { get; set;}
        public EmployeeDTO(string name, List<int> subordinates, DTO.EmployeeDTO leader = null)
        {
            Name = name;
            Leader = leader;
            SubordinatesID = subordinates;
            TaskList = new List<int>();
        }
        
    }
}