using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Library.DataProcessors;
using BlogMVC.Models;
using BlogMVC.Models.DisplayModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostProcessor _postProcessor;
        private readonly ICategoryProcessor _categoryProcessor;
        private readonly ICommentProcessor _commentProcessor;

        public PostController(ILogger<HomeController> logger, IPostProcessor postProcessor,
            ICategoryProcessor categoryProcessor, ICommentProcessor commentProcessor)
        {
            _logger = logger;
            _postProcessor = postProcessor;
            _categoryProcessor = categoryProcessor;
            _commentProcessor = commentProcessor;
        }

        [Authorize(Roles ="Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreatePost(PostModel model)
        {
            _postProcessor.CreatePost(model.Title, model.Content, model.CategoryId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ViewPost(int postId)
        {
            var loadPost = _postProcessor.LoadPostById(postId).FirstOrDefault();
            var loadComments = _commentProcessor.LoadComments(postId).OrderByDescending(x => x.CreatedDate);
            PostDisplayModel post = new PostDisplayModel
            {
                Id = loadPost.Id,
                AuthorName = loadPost.AuthorName,
                Title = loadPost.Title,
                Content = loadPost.Content,
                CreatedDate = loadPost.CreatedDate,
                CategoryName = loadPost.CategoryName
            };

            List<CommentDisplayModel> commentList = new List<CommentDisplayModel>();

            foreach (var comment in loadComments)
            {
                CommentDisplayModel model = new CommentDisplayModel
                {
                    Id = comment.Id,
                    PostId = comment.PostId,
                    UserName = comment.UserName,
                    Content = comment.Content,
                    CreatedDate = comment.CreatedDate
                };
                commentList.Add(model);
            }

            post.Comments = commentList;
            //PostModel post = new PostModel
            //{
            //    Id = load.Id,
            //    AuthorId = load.AuthorId,
            //    Title = load.Title,
            //    Content = load.Content,
            //    CreatedDate = load.CreatedDate,
            //    CategoryId = load.CategoryId
            //};

            return View(post);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditPost(int postId)
        {
            var loadPost = _postProcessor.LoadPostById(postId).FirstOrDefault();
            PostDisplayModel post = new PostDisplayModel
            {
                Id = loadPost.Id,
                AuthorName = loadPost.AuthorName,
                Title = loadPost.Title,
                Content = loadPost.Content,
                CreatedDate = loadPost.CreatedDate,
                CategoryName = loadPost.CategoryName
            };
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditPost(PostDisplayModel model)
        {
            _postProcessor.EditPost(model.Id, model.Title, model.Content);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeletePost(int postId)
        {
            _postProcessor.DeletePost(postId);

            return RedirectToAction("Index", "Home");
        }
    }
}
