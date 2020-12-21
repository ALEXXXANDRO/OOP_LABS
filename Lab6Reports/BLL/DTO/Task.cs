using System;
using System.Collections.Generic;
using Lab6Reports.Collections;
using Lab6Reports.DAL;

namespace Lab6Reports.BLL.DTO
{
    public class TaskDTO : BaseDTOEntities
    {
        public List<Triad<DateTime, int, string>> Logger { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        
        public TaskState State { get; set;}

        public int OwnerID { get; set; }
        public TaskDTO(string name, string description, TaskState state , int owner)
        {
            Name = name;
            Description = description;
            State = state;
            OwnerID = owner;
            Logger = new List<Triad<DateTime, int, string>>();
        }
    }
}