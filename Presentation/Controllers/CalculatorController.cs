using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Services;
using Application.DTO;

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
            return View(new ResultModel<CalculateValute>()
            {
                Code = 300
            });
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromForm] CalculateValute calculateValue)
        {
            ViewData["cookie"] = "cal";

            if (ModelState.IsValid && calculateValue.basiccurrencyinput != 0 &&
                calculateValue.basiccurrencycode != "Choose..." &&
                calculateValue.targetcurrencycode != "Choose...")
            {
                var result = await _calculatorService.ExchangeRateAsync(calculateValue);

                return View("~/Views/Calculator/Index.cshtml", result);
            }
            else if(calculateValue.basiccurrencyinput <= 0)
            {
                return View("~/Views/Error/Index.cshtml", new ResultModel<object>() { Code = 404, Message = "you gave the wrong value" });
            }

            return View("~/Views/Calculator/Index.cshtml", new ResultModel<CalculateValute>()
            {
                Code = 300
            });
        }
    }
}