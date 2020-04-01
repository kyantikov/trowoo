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
    /// API controller class which inherits ControllerBase class, uses HighPriceService to process/recieve data.
    /// ROUTE: '/alert/highprice'
    /// All methods return an HTTP Response.
    /// </summary>
    /// <remarks>
    /// <para>This class contains methods which are similarlly named in HighPriceService.</para>
    /// </remarks>
    [ApiController]
    [Route("alert/highprice")]
    public class HighPriceController : ControllerBase
    {
        private HighPriceService HighPriceService { get; }
        private ILogger Logger { get; }

        /// <summary>
        /// Constructor method injects HighPriceService and Logger into the class upon instantiation.
        /// </summary>
        /// <param name="highPriceService">HighPriceService class Dependency Injection.</param>
        /// <param name="logger">Logger Dependency Injection.</param>
        public HighPriceController(HighPriceService highPriceService, ILogger<HighPriceController> logger)
        {
            HighPriceService = highPriceService;
            Logger = logger;
        }

        /// <summary>
        /// GET request to retrieve a HighPrice with specified id.
        /// </summary>
        /// <param name="id">HighPrice id. An integer.</param>
        /// <returns>
        /// <para>Returns 200 if the HighPrice exists. HighPrice object returned.</para>
        /// <para>Returns 404 if the HighPrice does not exist.</para>
        /// </returns>
        [HttpGet("{id:int}")]
        public ActionResult<HighPrice> GetById([FromRoute] int id)
        {
            var highPrice = HighPriceService.GetById(id);
            if(highPrice == null)
            {
                return NotFound();
            }
            return Ok(highPrice);
        }

        /// <summary>
        /// POST request to create a HighPrice for a Position.
        /// </summary>
        /// <param name="highPrice">HighPrice object.</param>
        /// <returns>
        /// <para>Returns 201 if the HighPrice was successfully validated and created.</para>
        /// <para>Returns 404 if the HighPrice failed model validations and was not created and saved.</para>
        /// </returns>
        [HttpPost]
        public ActionResult<HighPrice> Create([FromBody] HighPrice highPrice)
        {
            highPrice = HighPriceService.Create(highPrice);
            return CreatedAtAction(nameof(GetById), new {id = highPrice.Id}, highPrice);
        }

        /// <summary>
        /// PUT request to update a HighPrice with the specified id.
        /// </summary>
        /// <param name="id">HighPrice Id. An integer.</param>
        /// <param name="price">Updated price value. A decimal.</param>
        /// <returns>
        /// <para>Returns 200 if the HighPrice was successfully validated, updated, and saved.</para>
        /// <para>Returns 404 if the HighPrice does not exist.</para>
        /// <para>Returns 404 if the HighPrice failed model validations and was not upated and saved.</para>
        /// </returns>
        [HttpPut("{id:int}")]
        public ActionResult<HighPrice> Update([FromRoute] int id, [FromBody] decimal price)
        {
            var highPrice = HighPriceService.Update(id, price);
            if(highPrice == null)
            {
                return NotFound();
            }
            return Ok(highPrice);
        }

        /// <summary>
        /// DELETE request to delete a HighPrice with the specified id.
        /// </summary>
        /// <param name="id">HighPrice id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a HighPrice that does not exist.
        /// </exception>
        /// <returns>
        /// <para>Returns 200 if the HighPrice was successfully deleted.</para>
        /// <para>Returns 404 if the HighPrice does not exist.</para>
        /// </returns>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                HighPriceService.Delete(id);
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