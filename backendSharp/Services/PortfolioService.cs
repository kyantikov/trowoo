using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;


namespace Trowoo.Services
{
    /// <summary>
    /// The PortfolioService contains all methods necessary to create, read update or delete a portfolio for a user.
    /// </summary>
    /// <remarks>
    /// <para>This class has the following methods:</para>
    /// <para>Create, GetUserPortfolios, Update, Delete, GetById</para>
    /// </remarks>
    public class PortfolioService
    {
        private TrowooDbContext TrowooDbContext;

        /// <summary>
        /// Constructor method injects the dependency of type TrowooDbContext into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection.</param>
        public PortfolioService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// Creates a Portfolio for a user.
        /// </summary>
        /// <param name="portfolio">Portfolio object.</param>
        /// <returns>Portfolio object originally passed as an argument.</returns>
        public Portfolio Create(Portfolio portfolio)
        {
            TrowooDbContext.Portfolios.Add(portfolio);
            TrowooDbContext.SaveChanges();
            return portfolio;
        }

        /// <summary>
        /// This method retrieves all Portfolios for a specified userId.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>List of Portfolios.</returns>
        public List<Portfolio> GetUserPortfolios(string userId)
        {
            return TrowooDbContext.Portfolios.Where(p => p.UserId == userId).ToList();
        }
        /// <summary>
        /// Updates a Portfolio's name for a specified id.
        /// </summary>
        /// <param name="id">Portfolio Id.</param>
        /// <param name="name">Updated name.</param>
        /// <returns>Updated Portfolio object.</returns>
        public Portfolio Update(int id, string name)
        {
            var portfolio = GetById(id);
            if(portfolio == null){
                return null;
            }
            portfolio.Name = name;
            TrowooDbContext.Update(portfolio);
            TrowooDbContext.SaveChanges();
            return portfolio;
        }

        /// <summary>
        /// Deletes a Portfolio for a specified id.
        /// </summary>
        /// <param name="id">Portfolio Id.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">Throws when attempting to
        /// delete an entity in the database with <paramref name="id"/></exception>
        public void Delete(int id)
        {
            try
            {
                TrowooDbContext.Portfolios.Remove(new Portfolio{Id = id});
                TrowooDbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new EntityDoesNotExistException($"Portfolio with id: '{id}' does not exist", exception);
            }
        }

        /// <summary>
        /// Queries the database for a Portfolio with the specified id.
        /// </summary>
        /// <param name="id">Portfolio id.</param>
        /// <returns>Portfolio object.</returns>
        public Portfolio GetById(int id)
        {
            return TrowooDbContext.Portfolios.Find(id);
        }
    }
}