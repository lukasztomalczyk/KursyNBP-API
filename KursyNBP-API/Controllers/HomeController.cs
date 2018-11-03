using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kursyNBP.Models;
using NBPApiClientCore;
using System.Collections.Generic;
using System.Linq;
using NBPApiClientCore.Currency;

namespace kursyNBP.Controllers
{
    public class HomeController : Controller
    {
        private ICurrencyApi _currencyApi;
        public HomeController(ICurrencyApi currencyApi)
        {
            _currencyApi = currencyApi;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Currency(DateTime dateFrom, DateTime dateTo)
        {

            if (dateFrom == DateTime.Parse("01.01.0001 00:00:00") || dateTo == DateTime.Parse("01.01.0001 00:00:00"))
            {
                dateFrom = DateTime.Now.AddDays(-1);
                dateTo = DateTime.Now;
            } 

            var CurrencyList =
               _currencyApi.GetCurrenciesFromApi(dateFrom, dateTo);
            return View(CurrencyList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
