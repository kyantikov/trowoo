using System;

namespace Trowoo.Services
{
    /// <summary>
    /// Custom exception to be thrown when an entity Does Exist in the Database.
    /// Implementations:
    /// <see cref="SecurityService.Update(Models.Security)"/>
    /// <see cref="SecurityService.AddQuotesToSecurity(Models.Security, List<Quote>)"/>
    /// </summary>
    public class EntityExistsException : Exception
    {
        public EntityExistsException(string message) : base(message)
        {
        }
        public EntityExistsException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}