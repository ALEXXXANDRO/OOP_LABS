using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Lab6Reports.BLL.DTO;
using Lab6Reports.Collections;
using Lab6Reports.DAL;

namespace Lab6Reports.BLL
{
    public class TaskManager
    {
        Reposirory<TaskDAL> _taskReposirory;
        Reposirory<EmployeeDAL> _employeeReposirory;
        EmployeeManager _employeeManager;
        public TaskDAL ToDALConverter(TaskDTO task)
        {
            EmployeeDAL owner = _employeeReposirory.Get(task.OwnerID);
            var DALTask = new TaskDAL(task.Name, task.Description,task.State,task.OwnerID);
            DALTask.Logger = task.Logger;
            return DALTask;
        }
        public TaskDTO ToDTOConverter(TaskDAL task)
        {
            var DTOTask = new TaskDTO(task.Name,task.Description,task.State,task.OwnerID);
            DTOTask.State = task.State;
            DTOTask.ID = task.ID;
            DTOTask.Logger = task.Logger;
            return DTOTask;
        }
        
        public void Add(TaskDTO task, int employeeID)
        {
            var log = new Triad<DateTime, int, string> (DateTime.Today, employeeID, " Created " );
            task.Logger.Add(log); 
            var DALTask = ToDALConverter(task);
            _taskReposirory.Create(DALTask);
            task.ID = DALTask.ID;
            
            EmployeeDTO owner = _employeeManager.Get(task.OwnerID);
            owner.TaskList.Add(task.ID);
            _employeeManager.Update(owner,owner.ID);
        }

        public TaskDTO Get(int id)
        {
            TaskDAL task = _taskReposirory.Get(id); ;
            var t = ToDTOConverter(task);
            return t;
        }

        public List<TaskDTO> GetAll()
        {
            List<TaskDAL> DALTaskList = _taskReposirory.GetAll();
            List<TaskDTO> DTOTaskList = new List<TaskDTO>();
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
        public void Update(TaskDTO task, int employeeID, int ToChangeTaskId)
        {
            if (Get(ToChangeTaskId).State == TaskState.Resolved) { throw new ResolvedTask();}
            var discriptionLog = $"Update : task.Name = {task.Name} task.ownerID = {task.OwnerID}, task.description = {task.Description}, task.state = {task.State}";
            var log = new Triad<DateTime, int, string> (DateTime.Now, employeeID, discriptionLog);
            TaskDAL DALTask = _taskReposirory.GetAll().Find(t => t.ID.Equals(ToChangeTaskId));
            task.Logger.AddRange(DALTask.Logger);
            task.Logger.Add(log);
            _taskReposirory.Update(ToDALConverter(task), ToChangeTaskId);
        }

        public List<TaskDTO> GetTaskByCreateTime(DateTime date)
        {
            return GetAll().FindAll(t => t.Logger.First().First.Equals(date));
        }
        public List<TaskDTO> GetTaskByChangeTime(DateTime date)
        {
            return GetAll().FindAll(t => t.Logger.Last().First.Equals(date));
        }
        public List<TaskDTO> GetTaskByOwner(int employeeID)
        {
            return GetAll().FindAll(t => t.OwnerID.Equals(employeeID));
        }
        public List<TaskDTO> GetTaskByEditor(int employeeID)
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
                TaskDTO task = Get(taskID);
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
                TaskDTO task = Get(taskID);
                if (task.State == TaskState.Resolved)
                {
                    TaskList.Add(task.ID);
                }
            }

            return TaskList;
        }
        public TaskManager(string taskPath, string employeePath)
        {
            _taskReposirory = new Reposirory<TaskDAL>(taskPath);
            _employeeReposirory = new Reposirory<EmployeeDAL>(employeePath);
            _employeeManager = new EmployeeManager(employeePath);
        }
    }
}