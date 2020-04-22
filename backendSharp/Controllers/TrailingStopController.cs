using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trowoo.Models;
using Trowoo.Services;

namespace Trowoo.Controllers
{
    /// <summary>
    /// API controller class which inherits ControllerBase class, uses TrailingStopService to process/recieve data.
    /// ROUTE: '/alert/trailingstop'
    /// All methods return an HTTP Response.
    /// </summary>
    /// <remarks>
    /// <para>This class contains methods which are similarlly named in TrailingStopService.</para>
    /// </remarks>
    [ApiController]
    [Route("alert/trailingstop")]
    public class TrailingStopController : ControllerBase
    {
        private TrailingStopService TrailingStopService { get; }
        private ILogger<TrailingStopController> Logger { get; }

        /// <summary>
        /// Constructor method injects TrailingStopService and Logger into the class upon instantiation.
        /// </summary>
        /// <param name="trailingStopService">TrailingStopService class Dependency Injection.</param>
        /// <param name="logger">Logger Dependency Injection.</param>
        public TrailingStopController(TrailingStopService trailingStopService, ILogger<TrailingStopController> logger)
        {
            TrailingStopService = trailingStopService;
            Logger = logger;
        }

        /// <summary>
        /// GET request to retrieve TrailingStop with specified id.
        /// </summary>
        /// <param name="id">TrailingStop Id. An integer.</param>
        /// <returns>
        /// <para>Returns 200 if TrailingStop exists. TrailingStop object returned.</para>
        /// <para>Returns 404 if TrailingStop does not exist.</para>
        /// </returns>
        [HttpGet("{id:int}")]
        public ActionResult<TrailingStop> GetById(int id)
        {
            var trailingStop = TrailingStopService.GetById(id);
            if(trailingStop == null)
            {
                return NotFound();
            }
            return Ok(trailingStop);
        }

        /// <summary>
        /// POST request to create a TrailingStop for a Position.
        /// </summary>
        /// <param name="trailingStop">TrailingStop object.</param>
        /// <returns>
        /// <para>Returns 201 if TrailingStop was successfully validated and saved.</para>
        /// <para>Returns 404 if TrailingStop failed model validation and was not created andsaved.</para>
        /// </returns>
        [HttpPost]
        public ActionResult<TrailingStop> Create([FromBody] TrailingStop trailingStop)
        {
            trailingStop = TrailingStopService.Create(trailingStop);
            return CreatedAtAction("GetById", new {id = trailingStop.Id}, trailingStop);
        }

        /// <summary>
        /// PUT request to update a TrailingStop with the specified id.
        /// </summary>
        /// <param name="id">TrailingStop Id. An integer.</param>
        /// <param name="percent">Updated percent value. A decimal.</param>
        /// <returns>
        /// <para>Returns 200 if the TrailingStop was successfully updated and saved.</para>
        /// <para>Returns 404 if the TrailingStop does not exist.</para>
        /// <para>Returns 404 if the TrailingStop failed validation and was not updated and saved.</para>
        /// </returns>
        [HttpPut]
        public ActionResult<TrailingStop> Update([FromBody] int id,[FromBody] decimal percent)
        {
            var trailingStop = TrailingStopService.Update(id, percent);
            if(trailingStop == null)
            {
                return NotFound();
            }
            return Ok(trailingStop);
        }

        /// <summary>
        /// DELETE request to delete a TrailingStop with the specified id.
        /// </summary>
        /// <param name="id">TrailingStop id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a TrailingStop that does not exist.
        /// </exception>
        /// <returns>
        /// <para>Returns 200 if the TrailingStop was successfully deleted.</para>
        /// <para>Returns 404 if the TrailingStop does not exist.</para>
        /// </returns>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                TrailingStopService.Delete(id);
                return Ok();
            }
            catch(EntityDoesNotExistException exception)
            {
                Logger.LogWarning(exception, exception.Message);
                return NotFound();
            }
        }
    }
}