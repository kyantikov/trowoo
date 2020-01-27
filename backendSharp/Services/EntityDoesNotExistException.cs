using System;

namespace Trowoo.Services
{
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}