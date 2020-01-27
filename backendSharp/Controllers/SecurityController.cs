using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trowoo.Models;
using Trowoo.Services;

namespace Trowoo.Controllers
{
    [ApiController]
    [Route("security")]
    public class SecurityController : ControllerBase
    {
        private SecurityService SecurityService;
        private readonly ILogger<SecurityController> Logger;

        public SecurityController(SecurityService securityService, ILogger<SecurityController> logger)
        {
            SecurityService = securityService;
            Logger = logger;
        }

        [HttpPost]
        public ActionResult<Security> FindOrCreate([FromBody] Security security)
        {
            security = SecurityService.FindOrCreate(security);
            return CreatedAtAction(nameof(GetById), new {id = security.Id}, security);
        }

        [HttpGet("{id}")]
        public ActionResult<Security> GetById(int id)
        {
            var security = SecurityService.GetById(id);
            if(security == null)
            {
                return NotFound();
            }
            return Ok(security);
        }
        
        [HttpGet]
        public ActionResult<List<Security>> GetAll()
        {
            return SecurityService.GetAll();
        }

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

        [HttpDelete("{id}")]
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