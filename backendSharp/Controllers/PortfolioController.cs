using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Trowoo.Models;
using Trowoo.Services;

namespace Trowoo.Controllers
{
    /// <summary>
    /// API controller class which inherits ControllerBase class, uses PortfolioService to process/recieve data.
    /// ROUTE: '/portfolio'
    /// All methods return an HTTP Response.
    /// </summary>
    /// <remarks>
    /// <para>This class contains methods which are similarlly named in PortfolioService.</para>
    /// </remarks>
    
    [Authorize]
    [ApiController]
    [Route("portfolio")]
    public class PortfolioController : ControllerBase
    {
        private PortfolioService PortfolioService;
        private readonly ILogger<PortfolioController> Logger;

        /// <summary>
        /// Constructor method injects PortfolioService and Logger into the class upon instantiation.
        /// </summary>
        /// <param name="portfolioService">PortfolioService class Dependency Injection.</param>
        /// <param name="logger">Logger Dependency Injection.</param>
        public PortfolioController(PortfolioService portfolioService, ILogger<PortfolioController> logger)
        {
            PortfolioService = portfolioService;
            Logger = logger;
        }

        /// <summary>
        /// GET request to retrieve Portfolio by id.
        /// </summary>
        /// <param name="id">Portfolio Id. An integer.</param>
        /// <returns>
        /// <para>Returns 200 if Portfolio exists. Portfolio object returned.</para>
        /// <para>Returns 404 if Portfolio does not exist.</para>
        /// </returns>
        [HttpGet("{id:int}")]
        public ActionResult<Portfolio> GetById(int id)
        {
            var portfolio = PortfolioService.GetById(id);
            if(portfolio == null)
            {
                return NotFound();
            }
            return Ok(portfolio);
        }

        /// <summary>
        /// GET request to retrieve all Securities for a user.
        /// </summary>
        /// <param name="userId">User Id; passed through body.</param>
        /// <returns>List of Portfolios for a user.</returns>
        [HttpGet]
        public ActionResult<List<Portfolio>> GetUserPortfolios()
        {
            return PortfolioService.GetUserPortfolios(User.GetId());
        }

        /// <summary>
        /// POST request to create Portfolio for a user.
        /// </summary>
        /// <param name="portfolio">Portfolio object.</param>
        /// <returns>
        /// <para>Returns 201 if Portfolio is successfully validated, created, and saved.</para>
        /// <para>Returns 404 if validation fails and Portfolio is not created and saved. </para>
        /// </returns>
        [HttpPost]
        public ActionResult<Portfolio> Create([FromBody] Portfolio portfolio)
        {
            if(portfolio.UserId != User.GetId())
            {
                return Conflict();
            }
            portfolio = PortfolioService.Create(portfolio);
            return CreatedAtAction(nameof(GetById), new {id = portfolio.Id}, portfolio);
        }

        /// <summary>
        /// PUT request to update ONLY name of existing Portfolio.
        /// </summary>
        /// <param name="id">Portfolio Id. An integer.</param>
        /// <param name="name">Updated Portfolio name. A string. </param>
        /// <returns>
        /// <para>Returns 200 if the Portfolio was successfully validated and updated. Updated Portfolio object returned.</para>
        /// <para>Returns 404 if a Portfolio with specified id does not exist.</para>
        /// <para>Returns 404 if updating the Portfolio to new values fails the model validations.</para>
        /// </returns>
        [HttpPut("{id:int}")]
        public ActionResult<Portfolio> Update([FromRoute] int id ,[FromBody] string name)
        {
            var portfolio = PortfolioService.Update(id, name, User.GetId());
            if(portfolio == null)
            {
                return NotFound();
            }
            return Ok(portfolio);
        }

        /// <summary>
        /// DELETE request to delete a portfolio.
        /// </summary>
        /// <param name="id">Portfolio Id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a Portfolio that does not exist.
        /// </exception>
        /// <returns>
        /// <para>Returns 200 if the Portfolio was successfully deleted.</para>
        /// <para>Returns 404 if the Portfolio with specified id does not exist.</para>
        /// </returns>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                PortfolioService.Delete(id, User.GetId());
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