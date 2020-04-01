using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;

namespace Trowoo.Services
{
    /// <summary>
    /// The PositionService contains all methods necessary to create, read, update or delete a position within a portfolio.
    /// </summary>
    /// <remarks>
    /// <para>This class has the following methods:</para>
    /// <para>GetById, Create, UpdateSecurityForPosition, Update, Delete</para>
    /// </remarks>
    public class PositionService
    {
        private TrowooDbContext TrowooDbContext { get; }
        private PortfolioService PortfolioService { get; }
        private SecurityService SecurityService { get; }

        /// <summary>
        /// Constructor method injects the dependency of type TrowooDbContext, PortfolioService, SecurityService into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection.</param>
        /// <param name="portfolioService">PortfolioService class dependency injection.</param>
        /// <param name="securityService">SecurityService class dependency injection.</param>
        /// <remarks>
        /// </remarks>
        public PositionService(
            TrowooDbContext trowooDbContext, 
            PortfolioService portfolioService, 
            SecurityService securityService
            )
        {
            TrowooDbContext = trowooDbContext;
            PortfolioService = portfolioService;
            SecurityService = securityService;
        }

        /// <summary>
        /// Retrieves Position with specified id.
        /// </summary>
        /// <param name="id">Position id. An integer.</param>
        /// <returns>Position object.</returns>
        public Position GetById(int id)
        {
            return TrowooDbContext.Positions.Find(id);
        }

        /// <summary>
        /// Creates a position for a security within a portfolio.
        /// </summary>
        /// <param name="position">Position object to add.</param>
        /// <param name="portfolioId">Portfolio Id. An integer.</param>
        /// <param name="securityId">Security Id. An integer.</param>
        /// <returns>New Portfolio object.</returns>
        /// <remarks>
        /// <para>Uses Portfolio- and SecurityService classes to obtain respective entities.</para>
        /// </remarks>
        public Position Create(Position position, int portfolioId, int securityId)
        {
            var portfolio = PortfolioService.GetById(portfolioId);
            var security = SecurityService.GetById(securityId);
            position.Security = security;
            TrowooDbContext.Positions.Add(position);
            portfolio.Positions.Add(position);
            TrowooDbContext.SaveChanges();
            return position;
        }

        /// <summary>
        /// Updates the Security for a position.
        /// </summary>
        /// <param name="id">Position Id. An integer.</param>
        /// <param name="ticker">Security ticker. A string.</param>
        /// <returns>Updated Position object.</returns>
        /// <remarks>
        /// <para>Uses SecurityService class to obtain security by ticker.</para>
        /// </remarks>
        public Position UpdateSecurityForPosition(int id, string ticker)
        {
            var position = GetById(id);
            var security = SecurityService.GetByTicker(ticker);
            if(position == null || security == null)
            {
                return null;
            }
            position.Security = security;
            TrowooDbContext.SaveChanges();
            return position;
        }

        /// <summary>
        /// Updates Position (OpenedDate, Cost).
        /// </summary>
        /// <param name="position">Position object.</param>
        /// <returns> 
        /// <para>Updated position object.</para>
        /// <para>Null if position is not found.</para>
        /// </returns>
        public Position Update(Position position)
        {
            var existingPosition = GetById(position.Id);
            if(existingPosition == null)
            {
                return null;
            }
            TrowooDbContext.Entry(existingPosition).CurrentValues.SetValues(position);
            TrowooDbContext.SaveChanges();
            return position;
        }

        /// <summary>
        /// Attempts to delete a Position with a specified id.
        /// </summary>
        /// <param name="id">Position Id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete an entity in the database with <paramref name="id"/>
        /// </exception>
        public void Delete(int id)
        {
            try
            {
                TrowooDbContext.Positions.Remove(new Position{Id = id});
                TrowooDbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new EntityDoesNotExistException($"Position with id: '{id}' does not exist", exception);
            }
        }
    }
}