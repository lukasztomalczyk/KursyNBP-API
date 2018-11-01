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
        private ICurrencyAPI _currencyApi;
        public HomeController(ICurrencyAPI currencyApi)
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
        public IActionResult Currency()
        {

            var CurrencyList =
                _currencyApi.GetCurrenciesFromApi(DateTime.Now.AddDays(-10), DateTime.Now);
            return View(CurrencyList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
