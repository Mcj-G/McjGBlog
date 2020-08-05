using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogMVC.Models;
using Blog.Library.DataProcessors;
using BlogMVC.Models.DisplayModels;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostProcessor _postProcessor;

        public HomeController(ILogger<HomeController> logger, IPostProcessor postProcessor)
        {
            _logger = logger;
            _postProcessor = postProcessor;
        }

        public IActionResult Index()
        {
            var posts = _postProcessor.LoadPosts().OrderByDescending(x => x.CreatedDate);
            List<PostDisplayModel> postModels = new List<PostDisplayModel>();
            foreach (var post in posts)
            {
                postModels.Add(new PostDisplayModel
                {
                    Id = post.Id,
                    AuthorName = post.AuthorName,
                    Title = post.Title,
                    Content = post.Content,
                    CreatedDate = post.CreatedDate,
                    CategoryName = post.CategoryName
                });
                //postModels.Add(new PostModel
                //{
                //    Id = post.Id,
                //    AuthorId = post.AuthorId,
                //    Title = post.Title,
                //    Content = post.Content,
                //    CreatedDate = post.CreatedDate,
                //    CategoryId = post.CategoryId
                //}); 
            }

            return View(postModels);
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
    }
}
