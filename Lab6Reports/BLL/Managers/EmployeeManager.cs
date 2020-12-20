using System.Collections.Generic;
using System.Linq;
using Lab6Reports.DAL;

namespace Lab6Reports.BLL
{
    public class EmployeeManager
    {
        DAL.Reposirory<DAL.Employee> _employeeReposirory;

        private DAL.Employee ToDALConverter(DTO.Employee employee)
        {
            DAL.Employee leader = _employeeReposirory.GetAll().
                Find(t => t.Leader.ID.Equals(employee.Leader.ID));
            var DALEmployee = new DAL.Employee(employee.Name, leader, employee.SubordinatesID );
            return DALEmployee;
        }
        private DTO.Employee ToDTOConverter(DAL.Employee employee)
        {
            DTO.Employee leader = GetAll().
                Find(t => t.ID.Equals(employee.Leader.ID));
            var DTOEmployee = new DTO.Employee(employee.Name, leader, employee.SubordinatesID );
            return DTOEmployee;
        }
        
        public void Add(DTO.Employee employee)
        {
            var DALEmployee = ToDALConverter(employee);
            _employeeReposirory.Create(DALEmployee);
            employee.ID = DALEmployee.ID;
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
            DAL.Employee dalEmployee = _employeeReposirory.GetAll().Find(t => t.ID.Equals(id));
            _employeeReposirory.Update(dalEmployee,id);
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
            _employeeReposirory = new Reposirory<Employee>("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\Employee.json");
        }
    }
}