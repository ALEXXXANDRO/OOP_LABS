using System;

namespace LAB1_PARSER
{
    public class IniUnknownSettingnameException : Exception
    {
        public IniUnknownSettingnameException(string message) : base(message)
        {
        }
    }

    public class IniTypeException : Exception
    {
        public IniTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class IniFormatException : Exception
    {
        public IniFormatException(string message) : base(message)
        {
        }
    }
}