using System;

namespace Trowoo.Services
{
    /// <summary>
    /// Custom exception to be thrown when an entity in Does Not Exist in the Database.
    /// Implementations:
    /// <see cref="SecurityService.Delete(int)"/>
    /// <see cref="PortfolioService.Delete(int)"/>
    /// <see cref="PositionService.Delete(int)"/>
    /// </summary>
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException(string message) : base(message)
        {
        }
        public EntityDoesNotExistException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}