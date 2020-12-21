using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Lab6Reports.DAL
{
    public class Reposirory<T> where T : BaseEntities
    {
        public string Path;
        public Reposirory(string path)
        {
            Path = path;
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
                using (StreamWriter sw = new StreamWriter(Path))
                {
                    sw.WriteLine("[]");
                }
            }
        }
        
        public List<T> GetAll()
        {
            var jsonString = File.ReadAllText(Path);
            var entitiesList = JsonSerializer.Deserialize<List<T>>(jsonString);
            return entitiesList;
        }
        
        public T Get(int id)
        {
            var jsonString = File.ReadAllText(Path);
            var entitiesList = JsonSerializer.Deserialize<List<T>>(jsonString); 
            T entitie = entitiesList.Find(x => x.ID.Equals(id));
            if(entitie == null){throw new NotFound();}
            return entitie;
        }

        public void Create(T item)
        {
            List<T> entitiesList = GetAll();
            entitiesList.Add(item);
            var jsonString = JsonSerializer.Serialize(entitiesList);
            using (var sr = new StreamWriter(Path, false))
            {
                sr.WriteLine(jsonString);
            };
        }

        public void Update(T item, int id)
        {
            Delete(id);
            item.ID = id;
            Create(item);
        }
        
        public void Delete(int id )
        {
            List<T> entitiesList = GetAll();
            T entitie = entitiesList.Find(x => x.ID.Equals(id));
            if(entitie == null){throw new NotFound();}
            entitiesList.Remove(entitie);
            var jsonString = JsonSerializer.Serialize(entitiesList);
            using (var sr = new StreamWriter(Path, false))
            {
                sr.WriteLine(jsonString);
            };
        }
        
    }
}