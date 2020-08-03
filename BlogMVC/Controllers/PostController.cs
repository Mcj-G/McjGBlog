using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Library.DataProcessors;
using BlogMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostProcessor _postProcessor;

        public PostController(ILogger<HomeController> logger, IPostProcessor postProcessor)
        {
            _logger = logger;
            _postProcessor = postProcessor;
        }
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(PostModel model)
        {
            _postProcessor.CreatePost(model.Title, model.Content, model.CategoryId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ViewPost(int postId)
        {
            var load = _postProcessor.LoadPostById(postId).FirstOrDefault();
            PostModel post = new PostModel
            {
                Id = load.Id,
                AuthorId = load.AuthorId,
                Title = load.Title,
                Content = load.Content,
                CreatedDate = load.CreatedDate,
                CategoryId = load.CategoryId
            };

            return View(post);
        }

        public IActionResult DeletePost(int postId)
        {
            _postProcessor.DeletePost(postId);

            return RedirectToAction("Index", "Home");
        }
    }
}
