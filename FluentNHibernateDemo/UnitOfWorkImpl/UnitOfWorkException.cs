using System;

namespace UnitOfWorkImpl
{
    public class UnitOfWorkException : Exception
    {
        public UnitOfWorkException(string msg) : base(msg)
        {
            
        }

        public UnitOfWorkException(string msg, Exception innerException) : base(msg, innerException)
        {
            
        }
    }
}