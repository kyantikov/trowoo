using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;

namespace Trowoo.Services
{
    /// <summary>
    /// The HighPriceService contains all methods necessary to create, read, update or delete a HighPrice for a Position.
    /// </summary>
    /// <remarks>
    /// <para>This class has the following methods:</para>
    /// <para>GetById, Create, Update, Delete</para>
    /// </remarks>
    public class HighPriceService
    {
        private TrowooDbContext TrowooDbContext { get ;}

        /// <summary>
        /// Constructor method injects the dependency of type TrowooDbContext into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection.</param>
        public HighPriceService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// Retrieves HighPrice with specified id.
        /// </summary>
        /// <param name="id">HighPrice Id. An integer.</param>
        /// <returns>HighPrice object.</returns>
        public HighPrice GetById(int id)
        {
            return TrowooDbContext.HighPrices.Find(id);
        }

        /// <summary>
        /// Creates a HighPrice for a Position.
        /// </summary>
        /// <param name="highPrice">HighPrice object to create.</param>
        /// <returns>Newly created HighPrice object.</returns>
        public HighPrice Create(HighPrice highPrice)
        {
            TrowooDbContext.Add(highPrice);
            TrowooDbContext.SaveChanges();
            return highPrice;
        }

        /// <summary>
        /// Updates a HighPrice with the specified id.
        /// </summary>
        /// <param name="id">HighPrice Id. An integer.</param>
        /// <param name="price">Updated price value. A decimal.</param>
        /// <returns>Updated HighPrice object.</returns>
        public HighPrice Update(int id, decimal price)
        {
            var highPrice = GetById(id);
            if(highPrice == null)
            {
                return null;
            }
            highPrice.Price = price;
            TrowooDbContext.SaveChanges();
            return highPrice;
        }

        /// <summary>
        /// Deletes a HighPrice with the specified id.
        /// </summary>
        /// <param name="id">HighPrice Id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a HighPrice that does not exist.
        /// </exception>
        public void Delete(int id)
        {
            try
            {
                TrowooDbContext.HighPrices.Remove(new HighPrice{Id = id});
                TrowooDbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new EntityDoesNotExistException($"HighPrice with id: '{id}' does not exist", exception);
            }
        }
    }
}