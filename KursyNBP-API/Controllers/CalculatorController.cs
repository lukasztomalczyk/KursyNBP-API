using System;
using System.Collections.Generic;
using System.Linq;
using kursyNBP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBPApiClientCore;

namespace kursyNBP.Controllers
{
    public class CalculatorController : Controller
    {
        private static List<CurrencyModel> GetCurrencyList()
        {
            List<CurrencyModel> CurrencyList = new List<CurrencyModel>();
            //CurrencyAPI.GetCurrenciesFromApi().ToList()
                //.ForEach(x => CurrencyList.Add(new CurrencyModel() { Kod = x.Kod, Kurs = x.Kurs, Waluta = x.Waluta }));
            return CurrencyList;
            
        }


        // GET: Calculator
        public ActionResult Index()
        {
            return View(GetCurrencyList());
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

           return View("Index", GetCurrencyList());
        }
        // POST: Calculator/Delete/5
    }
}