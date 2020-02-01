using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;


namespace Trowoo.Services
{
    /// <summary>
    /// Service layer class containing all methods for Security related database operations.
    /// </summary>
    /// <remarks>
    /// <para>This class has the following methods:</para>
    /// <para>FindOrCreate, GetAll, Update, Delete, GetById, GetByTicker</para>
    /// </remarks>
    public class SecurityService
    {
        private TrowooDbContext TrowooDbContext;
        /// <summary>
        /// Constructor method injects the dependency of type TrowooDbContext into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection.</param>
        public SecurityService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// Retrieves Security with specified id.
        /// </summary>
        /// <param name="id">Security Id. An integer.</param>
        /// <returns>Security object.</returns>
        public Security GetById(int id)
        {
            return TrowooDbContext.Securities.Find(id);
        }

        /// <summary>
        /// Retrieves Security with specified ticker.
        /// </summary>
        /// <param name="ticker">Security Ticker. A string.</param>
        /// <returns>Security object.</returns>
        public Security GetByTicker(string ticker)
        {
            return TrowooDbContext.Securities.Where(s => s.Ticker == ticker).FirstOrDefault();
        }

        /// <summary>
        /// Creates Security in DB if !exists.
        /// </summary>
        /// <param name="security">Security object.</param>
        /// <returns>Security object originally passed as an argument.</returns>
        public Security FindOrCreate(Security security)
        {
            var existingSecurity = GetByTicker(security.Ticker);
            if (existingSecurity != null)
            {
                return existingSecurity;
            }
            //
            TrowooDbContext.Add(security);
            TrowooDbContext.SaveChanges();
            return security;
        }

        /// <summary>
        /// Retrieves all Securities in the database.
        /// </summary>
        /// <returns>List of all Securities.</returns>
        public List<Security> GetAll()
        {
            return TrowooDbContext.Securities.ToList();
        }

        /// <summary>
        /// Updates a Security for a specified id.
        /// </summary>
        /// <param name="security">Updated Security object.</param>
        /// <returns>Updated Security object.</returns>
        public Security Update(Security security)
        {
            var existingSecurity = GetById(security.Id);
            if(existingSecurity == null)
            {
                return null;
            }
            if(GetByTicker(security.Ticker) != null)
            {
                throw new EntityExistsException($"Security with ticker: '{security.Ticker}' already exists");
            }
            TrowooDbContext.Entry(existingSecurity).CurrentValues.SetValues(security);
            TrowooDbContext.SaveChanges();
            return security;
        }
        
        /// <summary>
        /// Delete's Security with specified id.
        /// </summary>
        /// <param name="id">Security Id. An integer.</param>
        public void Delete(int id)
        {
            try
            {
                TrowooDbContext.Securities.Remove(new Security{Id = id});
                TrowooDbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new EntityDoesNotExistException($"Security with id: '{id}' does not exist", exception);
            }
        }
    }
}