using System;
using System.Diagnostics;
using kursyNBP.Models;
using Microsoft.AspNetCore.Mvc;
using NBPApiClientCore.Currency;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
   
        public HomeController()
        {

        }
        public IActionResult Index()
        {
            ViewData["cookie"] = "index";
            return View();
        }


        public IActionResult Author()
        {
            ViewData["cookie"] = "author";
            return View();
        }

    }
}
