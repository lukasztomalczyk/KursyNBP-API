﻿using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Application.Currency;

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
            ViewData["cookie"] = "kursy";
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Index([FromForm] DatePicker datePicker)
        {
            ViewData["cookie"] = "kursy";
            var dateNow = DateTime.Now;
            if ((DateTime.Compare(dateNow, datePicker.FromDate) >= 0 &&
                DateTime.Compare(dateNow, datePicker.ToDate) >=0 &&
                datePicker.FromDate < datePicker.ToDate) == true) 
            {
                var result = await _exchangeService.CurrenciesAsync(datePicker.FromDate, datePicker.ToDate);

                return View(result);
            }
            else
            {
                return View("~/Views/Error/Index.cshtml", new ResultModel<object>() { Code = 404, Message = "Zakres dat się nie zgadza!"});
            }

        }


    }
}