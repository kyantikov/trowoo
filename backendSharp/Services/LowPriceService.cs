using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;

namespace Trowoo.Services
{
    /// <summary>
    /// The LowPriceService contains all methods necessary to create, read, update or delete a LowPrice for a Position.
    /// </summary>
    /// <remarks>
    /// <para>This class has the following methods:</para>
    /// <para>GetById, Create, Update, Delete</para>
    /// </remarks>
    public class LowPriceService
    {
        private TrowooDbContext TrowooDbContext;

        /// <summary>
        /// Constructor method injects the dependency of type TrowooDbContext into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection.</param>
        public LowPriceService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// Queries database for LowPrice with specified id.
        /// </summary>
        /// <param name="id">LowPrice Id. An integer.</param>
        /// <returns>LowPrice object.</returns>
        public LowPrice GetById(int id)
        {
            return TrowooDbContext.LowPrices.Find(id);
        }

        /// <summary>
        /// Creates a LowPrice for a Position.
        /// </summary>
        /// <param name="lowPrice">LowPrice object to create.</param>
        /// <returns>Newly created LowPrice object.</returns>
        public LowPrice Create(LowPrice lowPrice)
        {
            TrowooDbContext.Add(lowPrice);
            TrowooDbContext.SaveChanges();
            return lowPrice;
        }

        /// <summary>
        /// Updates a LowPrice with the specified id.
        /// </summary>
        /// <param name="id">LowPrice Id. An integer.</param>
        /// <param name="price">Updated price value. A decimal.</param>
        /// <returns>Updated LowPrice object.</returns>
        public LowPrice Update(int id, decimal price)
        {
            var lowPrice = GetById(id);
            if(lowPrice == null)
            {
                return null;
            }
            lowPrice.Price = price;
            TrowooDbContext.SaveChanges();
            return lowPrice;
        }

        /// <summary>
        /// Deletes a LowPrice with the specified id.
        /// </summary>
        /// <param name="id">LowPrice Id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a LowPrice that does not exist.
        /// </exception>
        public void Delete(int id)
        {
            try
            {
                TrowooDbContext.LowPrices.Remove(new LowPrice{Id = id});
                TrowooDbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new EntityDoesNotExistException($"LowPrice with id: '{id}' does not exist", exception);
            }
        }
    }
}