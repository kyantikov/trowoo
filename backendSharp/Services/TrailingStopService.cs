using System.Linq;
using System.Collections.Generic;
using Trowoo.Models;
using Microsoft.EntityFrameworkCore;

// TODO: When creating a TrailingStop for a Position which already has one, operation fails due to unique constraint.
    // : However, the database still "psuedo" creates the entity -- that is, it uses one Id integer every time the constraint fails
    // : example:
        // create TrailingStop for positionId: 1 -> creates TrailingStop with id: 1
        // create TrailingStop for positionId: 1 again -> FAILS
        // delete TrailingStop with id: 1 -> success
        // create TrailingStop for positionId: 1 -> creates TrailingStop with id: 3

namespace Trowoo.Services
{
    /// <summary>
    /// The TrailingStopService contains all methods necessary to create, read, update or delete a TrailingStop for a Position.
    /// </summary>
    /// <remarks>
    /// <para>This class has the following methods:</para>
    /// <para>GetById, Create, Update, Delete</para>
    /// </remarks>
    public class TrailingStopService
    {
        private TrowooDbContext TrowooDbContext { get; }

        /// <summary>
        /// Constructor method injects the dependency of type TrowooDbContext into the class upon instantiation.
        /// </summary>
        /// <param name="trowooDbContext">Database Context dependecy injection.</param>
        public TrailingStopService(TrowooDbContext trowooDbContext)
        {
            TrowooDbContext = trowooDbContext;
        }

        /// <summary>
        /// Retrieves TrailingStop with specified id.
        /// </summary>
        /// <param name="id">TrailingStop Id. An integer.</param>
        /// <returns>TrailingStop object.</returns>
        public TrailingStop GetById(int id)
        {
            return TrowooDbContext.TrailingStops.Find(id);
        }

        /// <summary>
        /// Creates a TrailingStop for a Position.
        /// </summary>
        /// <param name="trailingStop">TrailingStop object to create.</param>
        /// <returns>Newly created TrailingStop object.</returns>
        public TrailingStop Create(TrailingStop trailingStop)
        {
            TrowooDbContext.Add(trailingStop);
            TrowooDbContext.SaveChanges();
            return trailingStop;
        }

        /// <summary>
        /// Updates a TrailingStop with the specified id.
        /// </summary>
        /// <param name="id">TrailingStop id. An integer.</param>
        /// <param name="percent">Updated percent value. A decimal.</param>
        /// <returns>TrailingStop object with updated values.</returns>
        public TrailingStop Update(int id, decimal percent)
        {
            var trailingStop = GetById(id);
            if(trailingStop == null)
            {
                return null;
            }
            trailingStop.Percent = percent;
            TrowooDbContext.SaveChanges();
            return trailingStop;
        }

        /// <summary>
        /// Deletes a TrailingStop with the specified id.
        /// </summary>
        /// <param name="id">TrailingStop id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a TrailingStop that does not exist.
        /// </exception>
        public void Delete(int id)
        {
            try
            {
                TrowooDbContext.TrailingStops.Remove(new TrailingStop{Id = id});
                TrowooDbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new EntityDoesNotExistException($"TrailingStop with id: '{id}' does not exist", exception);
            }
        }
    }
}