using System;

namespace Trowoo.Services
{
    /// <summary>
    /// Custom exception to be thrown when an entity Does Exist in the Database.
    /// Implementations:
    /// <see cref="SecurityService.Update(Models.Security)"/>
    /// </summary>
    public class EntityExistsException : Exception
    {
        public EntityExistsException(string message) : base(message)
        {
        }
    }
}