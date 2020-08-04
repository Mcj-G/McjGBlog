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
        private readonly ICategoryProcessor _categoryProcessor;

        public PostController(ILogger<HomeController> logger, IPostProcessor postProcessor,
            ICategoryProcessor categoryProcessor)
        {
            _logger = logger;
            _postProcessor = postProcessor;
            _categoryProcessor = categoryProcessor;
        }
        public IActionResult CreatePost()
        {
            var load = _categoryProcessor.LoadCategories();
            PostModel model = new PostModel();
            List<CategoryModel> list = new List<CategoryModel>();
            foreach (var category in load)
            {
                CategoryModel categoryModel = new CategoryModel();
                categoryModel.Id = category.Id;
                categoryModel.Name = category.Name;

                list.Add(categoryModel);
            }

            model.CategoryList = list;
            return View(model);
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
