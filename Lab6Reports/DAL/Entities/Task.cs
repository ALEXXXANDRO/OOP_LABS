using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Lab6Reports.Collections;

namespace Lab6Reports.DAL
{
    public class Task : BaseEntities
    {
        public List<Triad<DateTime, int, string>> Logger { get; set;}
        
        private static int nextID = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        
        public TaskState State { get; set;}

        public DAL.Employee Owner;
        public Task(string name, string description, TaskState state, Employee owner)
        {
            ID = nextID;
            nextID += 1;
            Name = name;
            Description = description;
            State = state;
            Owner = owner;
            Logger = new List<Triad<DateTime,int,string>>();
        }
        
        /// конструктор для дессeриализации
        public Task()
        {
        }
    }
}