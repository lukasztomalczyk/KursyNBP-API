using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBPApiClientCore;
using NBPApiClientCore.Currency;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExchangeController : Controller
    {
        private readonly IExchangeRateService _exchangeService;

        public ExchangeController(IExchangeRateService exchangeService)
        {
            _exchangeService = exchangeService;
        }
        
        [HttpGet("/{from?}/{to?}")]
        public async Task<ActionResult> Index([FromQuery] string from = null, [FromQuery] string to = null)
        {
            var result = await _exchangeService.CurrenciesAsync(default(DateTime), default(DateTime));
            
            
            return View();
        }


    }
}