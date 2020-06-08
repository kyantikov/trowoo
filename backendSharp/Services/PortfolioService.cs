using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Trowoo.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Trowoo.Services
{
    /// <summary>
    /// The PortfolioService contains all methods necessary to create, read, update or delete a portfolio for a user.
    /// </summary>
    /// <remarks>
    /// <para>This class has the following methods:</para>
    /// <para>GetById, GetUserPortfolios, Create, Update, Delete</para>
    /// </remarks>
    public class PortfolioService
    {
        private TrowooDbContext TrowooDbContext { get; }

        /// <summary>
        /// Constructor method injects the dependency of type TrowooDbContext into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection.</param>
        public PortfolioService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// Retrieves detailed Portfolio with the specified id.
        /// </summary>
        /// <param name="id">Portfolio id. An integer.</param>
        /// <returns>
        /// <para>Returns Portfolio object with eagerly loaded related entities.</para>
        /// </returns>
        public Portfolio GetByIdDetailed(int id)
        {
            return TrowooDbContext.Portfolios.Where(p => p.Id == id)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.Security)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.TrailingStop)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.LowPrice)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.HighPrice)
                .FirstOrDefault();
        }

        /// <summary>
        /// Retrieves non-detailed Portfolio with the specified id.
        /// </summary>
        /// <param name="id">Portfolio id. An integer.</param>
        /// <returns>Returns Portfolio object.</returns>
        public Portfolio GetById(int id)
        {
            return TrowooDbContext.Portfolios.Find(id);
        }

        /// <summary>
        /// This method retrieves all Portfolios for a specified userId.
        /// </summary>
        /// <param name="userId">User Id. A string.</param>
        /// <returns>
        /// <para>List of Portfolios.</para>
        /// <para>Eagerly loads Positions and all related entities w/i each Position.</para>
        /// </returns>
        public List<Portfolio> GetUserPortfolios(string userId)
        {
            return TrowooDbContext.Portfolios.Where(p => p.UserId == userId)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.Security)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.TrailingStop)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.LowPrice)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.HighPrice)
                .Include(p => p.Positions)
                    .ThenInclude(p => p.PositionPerformanceMetrics)
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<AllPortfolios> GetAllPortfoliosGridComponentData(string userId)
        {
            return GetUserPortfolios(userId)
                .SelectMany(portfolio => portfolio.Positions.DefaultIfEmpty().Select(position => new AllPortfolios(){
                    PortfolioId = portfolio.Id,
                    PortfolioName = portfolio.Name,
                    Position = position,
                }))
                .ToList();
        }

        /// <summary>
        /// Creates a new Portfolio for a user.
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
        /// Updates a Portfolio's name for a specified id.
        /// </summary>
        /// <param name="id">Portfolio Id. An integer</param>
        /// <param name="name">Updated name. A string.</param>
        /// <param name="userId">Okta-generated User Id. A string.</param>
        /// <returns>Updated Portfolio object.</returns>
        public Portfolio Update(int id, string name, string userId)
        {
            var portfolio = GetById(id);
            if(portfolio == null || portfolio.UserId != userId){
                return null;
            }
            portfolio.Name = name;
            TrowooDbContext.Update(portfolio);
            TrowooDbContext.SaveChanges();
            return portfolio;
        }

        /// <summary>
        /// Attempts to delete a Portfolio for a specified id.
        /// </summary>
        /// <param name="id">Portfolio Id. An integer.</param>
        /// <param name="userId">Okta-generated User Id. A string.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete an entity in the database with <paramref name="id"/>
        /// </exception>
        public void Delete(int id, string userId)
        {
            var portfolio = GetById(id);
            if(portfolio == null || portfolio.UserId != userId){
                throw new EntityDoesNotExistException($"Portfolio with id: '{id}' does not exist");
            }
            TrowooDbContext.Portfolios.Remove(portfolio);
            TrowooDbContext.SaveChanges();
        }
    }
}