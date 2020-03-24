using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Trowoo.Models;
using Trowoo.Services.MarketData;

namespace Trowoo.Controllers
{
    [Route("system")]
    public class SystemController : ControllerBase
    {
        private MarketDataService MarketDataService { get; }
        private ILogger<SystemController> Logger { get; }
        public SystemController(MarketDataService marketDataService, ILogger<SystemController> logger)
        {  
            MarketDataService = marketDataService;
            Logger = logger;
        }

        [HttpGet("quote")]
        public async Task<ActionResult> GetQuotes()
        {
            await MarketDataService.RetrieveMarketDataAsync();
            return Ok();
        }
    }
}