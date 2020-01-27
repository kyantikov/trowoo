using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;


namespace Trowoo.Services
{
    /// <summary>
    /// The PortfolioService class is a service layer class which contains 
    /// all methods necessary to create, read update or delete a portfolio for a user.
    /// </summary>
    public class PortfolioService
    {
        private TrowooDbContext TrowooDbContext;

        /// <summary>
        /// The constructor method of this class injects the dependency of type TrowooDbContext into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection</param>
        public PortfolioService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// Creates a portfolio based on a portfolio object passed through this method.
        /// </summary>
        /// <param name="portfolio">Portfolio object.</param>
        /// <returns>Returns the Portfolio object which was originally passed as an argument.</returns>
        public Portfolio Create(Portfolio portfolio)
        {
            TrowooDbContext.Portfolios.Add(portfolio);
            TrowooDbContext.SaveChanges();
            return portfolio;
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
        /// <summary>
        /// This method retrieves all portfolios for a specified userId.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>List of Portfolios.</returns>
        public List<Portfolio> GetUserPortfolios(string userId)
        {
            return TrowooDbContext.Portfolios.Where(p => p.UserId == userId).ToList();
        }
        /// <summary>
        /// Updates a portfolio's name for a specified id.
        /// </summary>
        /// <param name="id">Portfolio Id.</param>
        /// <param name="name">Name to be changed to.</param>
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
        /// Deletes a portfolio for a specified id.
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
    }
}