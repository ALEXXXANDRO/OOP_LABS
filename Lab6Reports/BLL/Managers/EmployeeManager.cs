using System.Collections.Generic;
using System.Linq;

namespace Lab6Reports.BLL
{
    public class EmployeeManager
    {
        DAL.Reposirory<DAL.Employee> _employeeReposirory;

        public DAL.Employee ToDALConverter(DTO.Employee employee)
        {
            var DALEmployee = new DAL.Employee(employee.Name, employee.SubordinatesID);
            if (employee.Leader != null)
            {
                DAL.Employee leader = _employeeReposirory.Get(employee.Leader.ID);
                DALEmployee.Leader = leader;
            }
            DALEmployee.SubordinatesID = employee.SubordinatesID;
            DALEmployee.TaskList = employee.TaskList;

            return DALEmployee;
        }
        public DTO.Employee ToDTOConverter(DAL.Employee employee)
        {
            var DTOEmployee = new DTO.Employee(employee.Name, employee.SubordinatesID);
            if (employee.Leader != null)
            {
                DTO.Employee leader = Get(employee.Leader.ID);
                DTOEmployee.Leader = leader;
            }
            DTOEmployee.SubordinatesID = employee.SubordinatesID;
            DTOEmployee.ID = employee.ID;
            DTOEmployee.TaskList = employee.TaskList;
            return DTOEmployee;
        }
        
        public void Add(DTO.Employee employee)
        {
            var DALEmployee = ToDALConverter(employee);
            _employeeReposirory.Create(DALEmployee);
            employee.ID = DALEmployee.ID;
            if (employee.Leader != null)
            {
                DTO.Employee leader = this.Get(employee.Leader.ID);
                leader.SubordinatesID.Add(employee.ID);
                this.Update(leader,leader.ID);
            }
        }

        public DTO.Employee Get(int id)
        {
            DAL.Employee employee = _employeeReposirory.Get(id);
            DTO.Employee t = ToDTOConverter(employee);
            return t;
        }

        public void Delete(int id)
        {
            _employeeReposirory.Delete(id);
        }

        public void Update(DTO.Employee employee, int id)
        { 
            DAL.Employee DALEmployee = ToDALConverter(employee);
            _employeeReposirory.Update(DALEmployee,id);
        }
        
        public List<DTO.Employee> GetAll()
        {
            List<DAL.Employee> DALEmployeeList = _employeeReposirory.GetAll();
            List<DTO.Employee> DTOEmployeeList = new List<DTO.Employee>();
            foreach (var task in DALEmployeeList)
            {
                var t = ToDTOConverter(task);
                DTOEmployeeList.Add(t);
            }

            return DTOEmployeeList;
        }

        public EmployeeManager()
        {
            _employeeReposirory = new DAL.Reposirory<DAL.Employee>("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\Employee.json");
        }
    }
}