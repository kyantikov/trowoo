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
    /// <para>API controller class with ROUTE: '/portfolio' which inherits ControllerBase class,</para>
    /// <para>uses PortfolioService to process/recieve data.</para>
    /// <para>All methods return an HTTP Response.</para>
    /// </summary>
    [ApiController]
    [Route("portfolio")]
    public class PortfolioController : ControllerBase
    {
        private PortfolioService PortfolioService;
        private readonly ILogger<PortfolioController> Logger;

        /// <summary>
        /// Constructor method injects PortfolioService and Logger into the class upon instantiation.
        /// </summary>
        /// <param name="portfolioService">PortfolioService Dependency Injection</param>
        /// <param name="logger">Logger Dependency Injection</param>
        public PortfolioController(PortfolioService portfolioService, ILogger<PortfolioController> logger)
        {
            PortfolioService = portfolioService;
            Logger = logger;
        }

        /// <summary>
        /// Retrieves portfolio by id from URL.
        /// </summary>
        /// <param name="id">Portfolio Id.</param>
        /// <returns>
        /// <para>Returns 200 if portfolio exists.</para>
        /// <para>Returns 404 if portfolio does not exist.</para>
        /// </returns>
        [HttpGet("{id}")]
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
        /// Retrieves all portfolios for user by userId FromBody.
        /// </summary>
        /// <param name="userId">User Id that is passed through the body.</param>
        /// <returns>List of portfolios for a user.</returns>
        [HttpGet]
        public ActionResult<List<Portfolio>> GetUserPortfolios([FromBody] string userId)
        {
            return PortfolioService.GetUserPortfolios(userId);
        }

        /// <summary>
        /// Creates a new portfolio for a user.
        /// </summary>
        /// <param name="portfolio">Portfolio object to be added.</param>
        /// <returns>
        /// <para>Returns 201 if successfully validated, created, and saved.</para>
        /// <para>Returns 404 if validation fails and entity is not created and saved. </para>
        /// </returns>
        [HttpPost]
        public ActionResult<Portfolio> Create([FromBody] Portfolio portfolio)
        {
            portfolio = PortfolioService.Create(portfolio);
            return CreatedAtAction(nameof(GetById), new {id = portfolio.Id, userId = portfolio.UserId}, portfolio);
        }

        /// <summary>
        /// Updates ONLY the name of a portfolio.
        /// </summary>
        /// <param name="id">Portfolio Id: route parameter</param>
        /// <param name="name">New portfolio name: request body </param>
        /// <returns>
        /// <para>Returns 200 if the portfolio was successfully updated.</para>
        /// <para>Returns 404 if a portfolio with specified does not exist.</para>
        /// <para>Returns 404 if updating the entity to new values fails the model validation.</para>
        /// </returns>
        [HttpPut("{id}")]
        public ActionResult<Portfolio> Update([FromRoute] int id ,[FromBody] string name)
        {
            var portfolio = PortfolioService.Update(id, name);
            if(portfolio == null)
            {
                return NotFound();
            }
            return Ok(portfolio);
        }

        /// <summary>
        /// Delete's a portfolio.
        /// </summary>
        /// <param name="id">Portfolio Id.</param>
        /// <returns>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">Throws when attempting to delete a portfolio an id that does not exist.</exception>
        /// <para>Returns 200 if the entity was successfully deleted.</para>
        /// <para>Returns 404 if the entity with specified id does not exist in the database.</para>
        /// </returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                PortfolioService.Delete(id);
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