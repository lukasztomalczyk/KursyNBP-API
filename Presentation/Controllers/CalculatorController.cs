using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            ViewData["cookie"] = "cal";
            return View();
        }
    }
}