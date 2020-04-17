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
    /// API controller class which inherits ControllerBase class, uses PositionService to process/recieve data.
    /// ROUTE: '/position'
    /// All methods return an HTTP Response.
    /// </summary>
    /// <remarks>
    /// <para>This class contains methods which are similarlly named in PositionService.</para>
    /// </remarks>
    [ApiController]
    [Route("position")]
    public class PositionController : ControllerBase
    {
        private PositionService PositionService { get; }
        private ILogger<PositionController> Logger { get; }

        /// <summary>
        /// Constructor method injects PositionService and Logger into the class upon instantiation.
        /// </summary>
        /// <param name="portfolioService">PositionService class Dependency Injection.</param>
        /// <param name="logger">Logger Dependency Injection.</param>
        public PositionController(PositionService positionService, ILogger<PositionController> logger)
        {
            PositionService = positionService;
            Logger = logger;
        }

        /// <summary>
        /// GET request to retrieve Position by id.
        /// </summary>
        /// <param name="id">Position Id. An integer.</param>
        /// <returns>
        /// <para>Returns 200 if Position exists. Position object returned.</para>
        /// <para>Returns 404 if Position does not exist.</para>
        /// </returns>
        [HttpGet("{id:int}")]
        public ActionResult<Position> GetById(int id)
        {
            var position = PositionService.GetById(id);
            if(position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }

        /// <summary>
        /// POST request to create a Position with a specific Security, within a Portfolio.
        /// </summary>
        /// <param name="position">Position object.</param>
        /// <param name="portfolioId">Portfolio Id. An integer.</param>
        /// <param name="securityId">Security Id. An integer.</param>
        /// <returns>
        /// <para>Returns 201 if Position is successfully validated, created, and saved.</para>
        /// <para>Returns 404 if validation fails and Position is not created and saved. </para>
        /// </returns>
        [HttpPost("{portfolioId:int}/{securityId:int}")]
        public ActionResult<Position> Create([FromBody] Position position, [FromRoute] int portfolioId, [FromRoute] int securityId)
        {
            position = PositionService.Create(position, portfolioId, securityId);
            return CreatedAtAction(nameof(GetById), new {id = position.Id}, position);
        }

        /// <summary>
        /// PUT request to update the Security that the Position is related to.
        /// </summary>
        /// <param name="id">Position Id. An integer.</param>
        /// <param name="ticker">Security ticker. A string.</param>
        /// <returns>
        /// <para>Returns 200 if the related Security was successfully updated.</para>
        /// <para>Returns 404 if the Position or Security do not exist.</para>
        /// </returns>
        [HttpPut]
        public ActionResult<Position> UpdateSecurityForPosition([FromBody] int id, [FromBody] string ticker)
        {
            var position = PositionService.UpdateSecurityForPosition(id, ticker);
            if(position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }

        /// <summary>
        /// PUT request to update values of a Position.
        /// </summary>
        /// <param name="position">Position object.</param>
        /// <returns>
        /// <para>Returns 200 if the Position was successfully validated and updated. Updated Position object returned.</para>
        /// <para>Returns 404 if a Position with the specified id does not exist.</para>
        /// <para>Returns 404 if updating the Position to new values fails the model validations.</para>
        /// </returns>
        [HttpPut]
        public ActionResult<Position> Update([FromBody] Position position)
        {
            position = PositionService.Update(position);
            if(position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }

        /// <summary>
        /// DELETE request to delete a Position.
        /// </summary>
        /// <param name="id">Position Id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a Position that does not exist.
        /// </exception>
        /// <returns>
        /// <para>Returns 200 if the Position was successfully deleted.</para>
        /// <para>Returns 404 if the Portfolio with the specified id does not exist.</para>
        /// </returns>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                PositionService.Delete(id);
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