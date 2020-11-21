using System;

namespace Lab4Backup
{
    
        public class NoSuchFile : Exception
        {
            public NoSuchFile (string message) : base(message)
            {
            }
        }
        public class FileAlreadyExists : Exception
        {
            public FileAlreadyExists (string message) : base(message)
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
            public NoOneAlgorithm  (string message) : base(message)
            {
            }
        }
        
        
}