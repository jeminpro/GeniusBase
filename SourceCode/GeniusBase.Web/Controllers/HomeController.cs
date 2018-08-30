using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeniusBase.Web.Models;
using GeniusBase.Core;
using GeniusBase.Core.Services;

namespace GeniusBase.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var dashboardViewModel = new DashboardViewModel();

            var categories = _postService.GetAllCategories();

            foreach (var cat in categories)
            {
                var categoryItem = new CategoryViewModel
                {
                    CategoryName = cat.CategoryName,
                    CategoryIdentifier = cat.CategoryIdentifier,
                    CategoryArticleCount = new Random().Next(cat.Id, cat.Id * 10)    //todo
                };

                dashboardViewModel.Categories.Add(categoryItem);
            }

            return View(dashboardViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
