using System;

namespace Lab4Backup
{
    
        public class FileAlreadyExists : Exception
        {
            public FileAlreadyExists(string filepath) : base($"Этот файл уже находится в бэкапе {filepath}")
            {
            }
        }
        public class RemoveError : Exception
        {
            public RemoveError (string message) : base(message)
            {
            }
        }
        public class NoOneAlgorithm : Exception
        {
            public NoOneAlgorithm () : base("Добавьте алгоритм для удаления")
            {
            }
        }
        
        
}