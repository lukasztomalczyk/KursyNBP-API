using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
        
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = await _exchangeService.CurrenciesAsync(default(DateTime), default(DateTime));

            return View(new ResultDTO() { Currencies = result });
        }

        [HttpPost]
        public async Task<ActionResult> Index([FromForm] DatePicker datePicker)
        {
            var result = await _exchangeService.CurrenciesAsync(datePicker.FromDate, datePicker.ToDate);

            return View(new ResultDTO() { Currencies = result });
        }


    }
}