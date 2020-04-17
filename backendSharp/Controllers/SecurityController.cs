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
    /// API controller class which inherits ControllerBase class, uses SecurityService process/recieve Security related data.
    /// ROUTE: '/security'
    /// All methods return an HTTP Response.
    /// </summary>
    /// <remarks>
    /// <para>This class contains methods which are similarlly named in SecurityService.</para>
    /// </remarks>
    [ApiController]
    [Route("security")]
    public class SecurityController : ControllerBase
    {
        private SecurityService SecurityService { get; }
        private ILogger<SecurityController> Logger { get; }

        /// <summary>
        /// Constructor method injects SecurityService and Logger into the class upon instantiation.
        /// </summary>
        /// <param name="securityService">SecurityService Dependency Injection.</param>
        /// <param name="logger">Logger Dependency Injection.</param>
        public SecurityController(SecurityService securityService, ILogger<SecurityController> logger)
        {
            SecurityService = securityService;
            Logger = logger;
        }

        /// <summary>
        /// GET request to retrieve all Securities.
        /// </summary>
        /// <returns>List of all Securities in database.</returns>
        [HttpGet]
        public ActionResult<List<Security>> GetAll()
        {
            var securityList = SecurityService.GetAll();
            return Ok(securityList);
        }

        /// <summary>
        /// GET request to retrieve a Security by id.
        /// </summary>
        /// <param name="id">Security Id. An integer.</param>
        /// <returns>
        /// <para>Returns 200 if Security exists. Security object returned.</para>
        /// <para>Returns 404 if Security does not exist.</para>
        /// </returns>
        [HttpGet("{id:int}")]
        public ActionResult<Security> GetById(int id)
        {
            var security = SecurityService.GetById(id);
            if(security == null)
            {
                return NotFound();
            }
            return Ok(security);
        }
        
        /// <summary>
        /// POST request to create Security.
        /// </summary>
        /// <param name="security">Security object.</param>
        /// <returns>
        /// <para>Returns 201 if Security is successfully validated, created, and saved.</para>
        /// <para>Returns 404 if validation fails and Security is not saved. </para>
        /// </returns>
        [HttpPost]
        public ActionResult<Security> FindOrCreate([FromBody] Security security)
        {
            security = SecurityService.FindOrCreate(security);
            return CreatedAtAction(nameof(GetById), new {id = security.Id}, security);
        }

        /// <summary>
        /// PUT request to update existing Security.
        /// </summary>
        /// <param name="security">Updated Security object.</param>
        /// <returns>
        /// <exception cref="Trowoo.Services.EntityExistsException">
        /// Throws when attempting to update an existing Security's ticker to a ticker which already exists in the database.
        /// </exception>
        /// <para>Returns 200 if the Security was successfully validated and updated. Updated Security object returned.</para>
        /// <para>Returns 404 if the Security with specified id does not exist.</para>
        /// <para>Returns 404 if updating the Security to new values fails the model validations.</para>
        /// <para>Returns 409 if updating Security.ticker results in an EntityExistsException.</para>
        /// </returns>
        [HttpPut]
        public ActionResult<Security> Update([FromBody] Security security)
        {
            try
            {
                security = SecurityService.Update(security);
                if(security == null)
                {
                    return NotFound();
                }
                return Ok(security);
            }
            catch(EntityExistsException exception)
            {
                Logger.LogWarning(exception, exception.Message);
                return Conflict();
            }
        }

        /// <summary>
        /// DELETE request to delete a Security.
        /// </summary>
        /// <param name="id">Security Id. An integer.</param>
        /// <exception cref="Trowoo.Services.EntityDoesNotExistException">
        /// Throws when attempting to delete a Security that does not exist.
        /// </exception>
        /// <returns>
        /// <para>Returns 200 if the Security was successfully deleted.</para>
        /// <para>Returns 404 if the Security with specified id does not exist.</para>
        /// </returns>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                SecurityService.Delete(id);
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