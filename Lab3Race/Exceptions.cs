using System;

namespace Lab3Race
{
    public class InvalidTransportType : Exception
    {
        public InvalidTransportType(string message) : base(message)
        {
        }
    }
    
    public class InvalidRaceType : Exception
    {
        public InvalidRaceType(string message) : base(message)
        {
        }
    }
    
    public class NoRiders : Exception
    {
        public NoRiders(string message) : base(message)
        {
        }
    }
}