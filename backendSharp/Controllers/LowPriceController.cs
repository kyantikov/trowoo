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
    /// API controller class which inherits ControllerBase class, uses LowPriceService to process/recieve data.
    /// ROUTE: '/alert/lowprice'
    /// All methods return an HTTP Response.
    /// </summary>
    /// <remarks>
    /// <para>This class contains methods which are similarlly named in LowPriceService.</para>
    /// </remarks>
    [ApiController]
    [Route("alert/lowprice")]
    public class LowPriceController : ControllerBase
    {
        private LowPriceService LowPriceService;
        private ILogger Logger;

        /// <summary>
        /// Constructor method injects LowPriceService and Logger into the class upon instantiation.
        /// </summary>
        /// <param name="trailingStopService">LowPriceService class Dependency Injection.</param>
        /// <param name="logger">Logger Dependency Injection.</param>
        public LowPriceController(LowPriceService lowPriceService, ILogger<LowPriceController> logger)
        {
            LowPriceService = lowPriceService;
            Logger = logger;
        }

        /// <summary>
        /// GET request to retrieve a LowPrice with specified id.
        /// </summary>
        /// <param name="id">LowPrice id. An integer.</param>
        /// <returns>
        /// <para>Returns 200 if the LowPrice exists. LowPrice object returned.</para>
        /// <para>Returns 404 if the LowPrice does not exist.</para>
        /// </returns>
        [HttpGet("{id:int}")]
        public ActionResult<LowPrice> GetById([FromRoute] int id)
        {
            var lowPrice = LowPriceService.GetById(id);
            if(lowPrice == null)
            {
                return NotFound();
            }
            return Ok(lowPrice);
        }

        /// <summary>
        /// POST request to create a LowPrice for a Position.
        /// </summary>
        /// <param name="lowPrice">LowPrice object.</param>
        /// <returns>
        /// <para>Returns 201 if the LowPrice was successfully validated and created.</para>
        /// <para>Returns 404 if the LowPrice failed model validations and was not created and saved.</para>
        /// </returns>
        [HttpPost]
        public ActionResult<LowPrice> Create([FromBody] LowPrice lowPrice)
        {
            lowPrice = LowPriceService.Create(lowPrice);
            return CreatedAtAction(nameof(GetById), new {id = lowPrice.Id}, lowPrice);
        }

        /// <summary>
        /// PUT request to update a LowPrice with the specified id.
        /// </summary>
        /// <param name="id">LowPrice Id. An integer.</param>
        /// <param name="price">Updated price value. A decimal.</param>
        /// <returns>
        /// <para>Returns 200 if the LowPrice was successfully validated, updated, and saved.</para>
        /// <para>Returns 404 if the LowPrice does not exist.</para>
        /// <para>Returns 404 if the LowPrice failed model validations and was not upated and saved.</para>
        /// </returns>
        [HttpPut("{id:int}")]
        public ActionResult<LowPrice> Update([FromRoute] int id, [FromBody] decimal price)
        {
            var lowPrice = LowPriceService.Update(id, price);
            if(lowPrice == null)
            {
                return NotFound();
            }
            return Ok(lowPrice);
        }

        /// <summary>
        /// DELETE request to delete a LowPrice with the specified id.
        /// </summary>
        /// <param name="id">LowPrice id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a LowPrice that does not exist.
        /// </exception>
        /// <returns>
        /// <para>Returns 200 if the LowPrice was successfully deleted.</para>
        /// <para>Returns 404 if the LowPrice does not exist.</para>
        /// </returns>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                LowPriceService.Delete(id);
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