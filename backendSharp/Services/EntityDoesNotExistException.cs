using System;

namespace Trowoo.Services
{
    /// <summary>
    /// Custom exception to be thrown when an entity in Does Not Exist in the Database.
    /// </summary>
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}