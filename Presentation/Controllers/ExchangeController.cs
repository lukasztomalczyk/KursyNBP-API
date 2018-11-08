using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;


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
        
        [HttpGet("{from?}/{to?}")]
        public async Task<ActionResult> Index([FromRoute] string from, [FromRoute] string to)
        {
            var result = await _exchangeService.CurrenciesAsync(from, to);

            return View(new ResultDTO() { Rattes = result.rates.ToList() });
        }
    }
}