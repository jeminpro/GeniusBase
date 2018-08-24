using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeniusBase.Web.Models;
using GeniusBase.Core;

namespace GeniusBase.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITest _test;

        public HomeController(ITest test)
        {
            _test = test;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public JsonResult About()
        {
            return Json(_test.TestMethod());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
