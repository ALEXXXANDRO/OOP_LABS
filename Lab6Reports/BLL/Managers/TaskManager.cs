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
            DAL.Employee owner = _employeeReposirory.Get(task.OwnerID);
            var DALTask = new DAL.Task(task.Name, task.Description,task.State,task.OwnerID);
            DALTask.Logger = task.Logger;
            return DALTask;
        }
        public DTO.Task ToDTOConverter(DAL.Task task)
        {
            var DTOTask = new DTO.Task(task.Name,task.Description,task.State,task.OwnerID);
            DTOTask.State = task.State;
            DTOTask.ID = task.ID;
            DTOTask.Logger = task.Logger;
            return DTOTask;
        }
        
        public void Add(DTO.Task task, int employeeID)
        {
            var log = new Triad<DateTime, int, string> (DateTime.Today, employeeID, " Created " );
            task.Logger.Add(log); 
            var DALTask = ToDALConverter(task);
            _taskReposirory.Create(DALTask);
            task.ID = DALTask.ID;
            
            DTO.Employee owner = _employeeManager.Get(task.OwnerID);
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
        public void Update(DTO.Task task, int employeeID, int ToChangeTaskId)
        {
            if (Get(ToChangeTaskId).State == TaskState.Resolved) { throw new ResolvedTask();}
            var discriptionLog = $"Update : task.Name = {task.Name} task.ownerID = {task.OwnerID}, task.description = {task.Description}, task.state = {task.State}";
            var log = new Triad<DateTime, int, string> (DateTime.Now, employeeID, discriptionLog);
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
        public List<DTO.Task> GetTaskByOwner(int employeeID)
        {
            return GetAll().FindAll(t => t.OwnerID.Equals(employeeID));
        }
        public List<DTO.Task> GetTaskByEditor(int employeeID)
        {
            return GetAll().FindAll(t => t.Logger.FindAll(editor 
                => editor.Second.Equals(employeeID)).Count > 0);
        }
        public List<int> GetSubordinatesTasks(int employeeID)
        {
            var TaskList = new List<int>();
            foreach (int EmploeeID in _employeeManager.Get(employeeID).SubordinatesID)
            {
               List<int> tmpList = _employeeReposirory.Get(EmploeeID).TaskList;
               TaskList.AddRange(tmpList);
            }

            return TaskList;
        }
        public List<int> GetResolvedDailyTasks(int employeeID)
        {
            
            var TaskList = new List<int>();
            foreach (int taskID  in _employeeManager.Get(employeeID).TaskList)
            {
                DTO.Task task = Get(taskID);
                if (task.State == TaskState.Resolved && task.Logger.Last().First - DateTime.Today < TimeSpan.FromDays(1))
                {
                    TaskList.Add(task.ID);
                }
            }

            return TaskList;
        }
        public List<int> GetResolvedTasks(int employeeID )
        {
            var TaskList = new List<int>();
            foreach (int taskID  in _employeeManager.Get(employeeID).TaskList)
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