using System;
using System.Collections.Generic;
using System.Linq;
using kursyNBP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBPApiClientCore;
using NBPApiClientCore.Currency;

namespace kursyNBP.Controllers
{
    public class CalculatorController : Controller
    {
        ICurrencyApi _currencyApi;
        public CalculatorController(ICurrencyApi currencyApi)
        {
            _currencyApi = currencyApi;
        }
        private IList<ICurrencyRate> GetTodayCurrencyList()
        {
            var CurrencyList =
                _currencyApi.GetCurrenciesFromApi(DateTime.Now.AddDays(-1), DateTime.Now).Select(x=>x.Value).FirstOrDefault();

            return CurrencyList;
            
        }


        // GET: Calculator
        public ActionResult Index()
        {
            return View(GetTodayCurrencyList());
        }

        // POST: Calculator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection currency)
        {
            decimal.TryParse(Request.Form["PLN"].First(), out var zl);
            decimal.TryParse(Request.Form["kurs"].First(), out var kurs);

            var currencyRate = new CurrencyRate();
            {
                currencyRate.Kurs = kurs;
                currencyRate.PLN = zl;
            }
          
            ViewBag.result = currencyRate.CalculateCurrency();
            ViewBag.LastAmount = zl;

           return View("Index", GetTodayCurrencyList());
        }
        // POST: Calculator/Delete/5
    }
}