using System;
using System.Collections.Generic;
using Lab6Reports.Collections;
using Lab6Reports.DAL;

namespace Lab6Reports.BLL.DTO
{
    public class Task : BaseDTOEntities
    {
        public List<Triad<DateTime, int, string>> Logger { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        
        public TaskState State { get; set;}

        public DTO.Employee Owner { get; set; }
        public Task(string name, string description, Employee owner)
        {
            Name = name;
            Description = description;
            State = TaskState.Open;
            Owner = owner;
            Logger = new List<Triad<DateTime, int, string>>();
        }
    }
}