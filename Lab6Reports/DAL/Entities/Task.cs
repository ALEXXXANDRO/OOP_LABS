using System.Security.Cryptography.X509Certificates;

namespace Lab6Reports.DAL
{
    public class Task : BaseEntities
    {
        private static int nextID = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        
        public State state { get; set;}
        public enum State
        {
            Open,
            Active,
            Resolved
        }

        public Employee owner;
        public Task(string name, string description)
        {
            ID = nextID;
            nextID += 1;
            Name = name;
            Description = description;
            state = State.Open;
        }
        
        /// конструктор для дессeриализации
        public Task()
        {
        }
    }
}