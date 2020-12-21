using System.Collections.Generic;
using System.Linq;
using Lab6Reports.BLL.DTO;
using Lab6Reports.DAL;

namespace Lab6Reports.BLL
{
    public class EmployeeManager
    {
        Reposirory<EmployeeDAL> _employeeReposirory;

        public EmployeeDAL ToDALConverter(EmployeeDTO employee)
        {
            var DALEmployee = new EmployeeDAL(employee.Name, employee.SubordinatesID);
            if (employee.Leader != null)
            {
                EmployeeDAL leader = _employeeReposirory.Get(employee.Leader.ID);
                DALEmployee.Leader = leader;
            }
            DALEmployee.SubordinatesID = employee.SubordinatesID;
            DALEmployee.TaskList = employee.TaskList;

            return DALEmployee;
        }
        public EmployeeDTO ToDTOConverter(EmployeeDAL employee)
        {
            var DTOEmployee = new EmployeeDTO(employee.Name, employee.SubordinatesID);
            if (employee.Leader != null)
            {
                EmployeeDTO leader = Get(employee.Leader.ID);
                DTOEmployee.Leader = leader;
            }
            DTOEmployee.SubordinatesID = employee.SubordinatesID;
            DTOEmployee.ID = employee.ID;
            DTOEmployee.TaskList = employee.TaskList;
            return DTOEmployee;
        }
        
        public void Add(EmployeeDTO employee)
        {
            var DALEmployee = ToDALConverter(employee);
            _employeeReposirory.Create(DALEmployee);
            employee.ID = DALEmployee.ID;
            if (employee.Leader != null)
            {
                EmployeeDTO leader = this.Get(employee.Leader.ID);
                leader.SubordinatesID.Add(employee.ID);
                this.Update(leader,leader.ID);
            }
        }

        public EmployeeDTO Get(int id)
        {
            EmployeeDAL employee = _employeeReposirory.Get(id);
            EmployeeDTO t = ToDTOConverter(employee);
            return t;
        }

        public void Delete(int id)
        {
            _employeeReposirory.Delete(id);
        }

        public void Update(EmployeeDTO employee, int id)
        { 
            EmployeeDAL DALEmployee = ToDALConverter(employee);
            _employeeReposirory.Update(DALEmployee,id);
        }
        
        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDAL> DALEmployeeList = _employeeReposirory.GetAll();
            List<EmployeeDTO> DTOEmployeeList = new List<EmployeeDTO>();
            foreach (var task in DALEmployeeList)
            {
                var t = ToDTOConverter(task);
                DTOEmployeeList.Add(t);
            }

            return DTOEmployeeList;
        }

        public EmployeeManager(string path)
        {
            _employeeReposirory = new DAL.Reposirory<EmployeeDAL>(path);
        }
    }
}