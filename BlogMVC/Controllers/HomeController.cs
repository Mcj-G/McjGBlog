using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogMVC.Models;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(PostModel model)
        {
            //TODO - makeing this work
            return RedirectToAction("Index");
        }

        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateComment(CommentModel model)
        {
            //TODO - makeing this work
            return RedirectToAction("Index");
        }
    }
}
