using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Library.DataProcessors;
using BlogMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly IPostProcessor _postProcessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommentProcessor _commentProcessor;

        public CommentController(IPostProcessor postProcessor, IHttpContextAccessor httpContextAccessor,
            ICommentProcessor commentProcessor)
        {
            _postProcessor = postProcessor;
            _httpContextAccessor = httpContextAccessor;
            _commentProcessor = commentProcessor;
        }

        public IActionResult CreateComment(int postId)
        {
            CommentModel comment = new CommentModel
            {
                PostId = postId
            };

            return View(comment);
        }

        [HttpPost]
        public IActionResult CreateComment(CommentModel model)
        {
            model.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            _commentProcessor.CreateComment(model.PostId, model.UserId, model.Content);

            return RedirectToAction("Index", "Home");
        }
    }
}
