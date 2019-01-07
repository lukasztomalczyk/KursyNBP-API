using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Services;

namespace Presentation.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }
        public IActionResult Index()
        {
            ViewData["cookie"] = "cal";
            return View(new CalculateValute() { });
        }

        [HttpPost]
        public IActionResult Calculate([FromForm] CalculateValute calculateValue)
        {
            ViewData["cookie"] = "cal";

            if (!ModelState.IsValid)
            {
                var test = _calculatorService.ExchangeRateAsync(calculateValue);
                calculateValue.targetcurrency = 12.1d;
                calculateValue.basiccurrency = 11d;
                calculateValue.value = 12.3d;
                return View("~/Views/Calculator/Index.cshtml", calculateValue);
            }
            calculateValue.targetcurrency = 12.1d;
            calculateValue.basiccurrency = 11d;
            calculateValue.value = 12.3d;
            return View("~/Views/Calculator/Index.cshtml", calculateValue);
        }
    }
}