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

        public int OwnerID { get; set; }
        
        public Task(string name, string description, TaskState state, int ownerID)
        {
            ID = nextID;
            nextID += 1;
            Name = name;
            Description = description;
            State = state;
            OwnerID = ownerID;
            Logger = new List<Triad<DateTime,int,string>>();
        }
        
        /// конструктор для дессeриализации
        public Task()
        { }
    }
}