using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Town()
        {
            ViewData["Message"] = "Town";

            return View();
        }

        public IActionResult Hero()
        {
            ViewData["Message"] = "Hero";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}
