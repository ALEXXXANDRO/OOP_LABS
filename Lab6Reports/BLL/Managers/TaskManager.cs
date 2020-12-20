using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Lab6Reports.Collections;

namespace Lab6Reports.BLL
{
    public class TaskManager
    {
        DAL.Reposirory<DAL.Task> _taskReposirory;
        DAL.Reposirory<DAL.Employee> _employeeReposirory;
        EmployeeManager _employeeManager;
        public DAL.Task ToDALConverter(DTO.Task task)
        {
            DAL.Employee owner = _employeeReposirory.Get(task.Owner.ID);
            var DALTask = new DAL.Task(task.Name, task.Description,task.State,owner);
            DALTask.Logger = task.Logger;
            return DALTask;
        }
        public DTO.Task ToDTOConverter(DAL.Task task)
        {
            DTO.Employee owner = _employeeManager.GetAll().Find(t => t.ID.Equals(task.Owner.ID));
            var DTOTask = new DTO.Task(task.Name, task.Description,owner);
            DTOTask.State = task.State;
            DTOTask.ID = task.ID;
            DTOTask.Logger = task.Logger;
            return DTOTask;
        }
        
        public void Add(DTO.Task task, DTO.Employee employee)
        {
            var log = new Triad<DateTime, int, string> (DateTime.Today, employee.ID, " Created " );
            task.Logger.Add(log); 
            var DALTask = ToDALConverter(task);
            _taskReposirory.Create(DALTask);
            task.ID = DALTask.ID;
            
            DTO.Employee owner = _employeeManager.Get(task.Owner.ID);
            owner.TaskList.Add(task.ID);
            _employeeManager.Update(owner,owner.ID);
        }

        public DTO.Task Get(int id)
        {
            DAL.Task task = _taskReposirory.Get(id); ;
            var t = ToDTOConverter(task);
            return t;
        }

        public List<DTO.Task> GetAll()
        {
            List<DAL.Task> DALTaskList = _taskReposirory.GetAll();
            List<DTO.Task> DTOTaskList = new List<DTO.Task>();
            foreach (var task in DALTaskList)
            {
                var t = ToDTOConverter(task);
                DTOTaskList.Add(t);
            }
            return DTOTaskList;
        }
        
        public void Delete(int id)
        {
            _taskReposirory.Delete(id);
        }
        public void Update(DTO.Task task, DTO.Employee employee, int ToChangeTaskId)
        {
            if (Get(ToChangeTaskId).State == TaskState.Resolved) { throw new ResolvedTask();}
            var discriptionLog = $"Update : task.Name = {task.Name} task.owner = {task.Owner.ID}, task.description = {task.Description}, task.state = {task.State}";
            var log = new Triad<DateTime, int, string> (DateTime.Now, employee.ID, discriptionLog);
            DAL.Task DALTask = _taskReposirory.GetAll().Find(t => t.ID.Equals(ToChangeTaskId));
            task.Logger.AddRange(DALTask.Logger);
            task.Logger.Add(log);
            _taskReposirory.Update(ToDALConverter(task), ToChangeTaskId);
        }

        public List<DTO.Task> GetTaskByCreateTime(DateTime date)
        {
            return GetAll().FindAll(t => t.Logger.First().First.Equals(date));
        }
        public List<DTO.Task> GetTaskByChangeTime(DateTime date)
        {
            return GetAll().FindAll(t => t.Logger.Last().First.Equals(date));
        }
        public List<DTO.Task> GetTaskByOwner(DTO.Employee employee)
        {
            return GetAll().FindAll(t => t.Owner.Equals(employee));
        }
        public List<DTO.Task> GetTaskByEditor(DTO.Employee employee)
        {
            return GetAll().FindAll(t => t.Logger.FindAll(editor 
                => editor.Second.Equals(employee.ID)).Count > 0);
        }
        public List<int> GetSubordinatesTasks(DTO.Employee employee)
        {
            var TaskList = new List<int>();
            foreach (int EmploeeID in employee.SubordinatesID)
            {
               List<int> tmpList = _employeeReposirory.Get(EmploeeID).TaskList;
               TaskList.AddRange(tmpList);
            }

            return TaskList;
        }
        public List<int> GetResolvedDailyTasks(DTO.Employee employee)
        {
            
            var TaskList = new List<int>();
            foreach (int taskID  in employee.TaskList)
            {
                DTO.Task task = Get(taskID);
                if (task.State == TaskState.Resolved && task.Logger.Last().First - DateTime.Today < TimeSpan.FromDays(1))
                {
                    TaskList.Add(task.ID);
                }
            }

            return TaskList;
        }
        public List<int> GetResolvedTasks(DTO.Employee employee)
        {
            var TaskList = new List<int>();
            foreach (int taskID  in employee.TaskList)
            {
                DTO.Task task = Get(taskID);
                if (task.State == TaskState.Resolved)
                {
                    TaskList.Add(task.ID);
                }
            }

            return TaskList;
        }
        public TaskManager()
        {
            _taskReposirory = new DAL.Reposirory<DAL.Task>("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\Task.json");
            _employeeReposirory = new DAL.Reposirory<DAL.Employee>("D:\\LABS\\2 COURSE\\OOP_LABS\\Lab6Reports\\Employee.json");
            _employeeManager = new EmployeeManager();
        }
    }
}