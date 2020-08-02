using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class CommentController : Controller
    {
        public CommentController()
        {

        }

        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateComment(CommentModel model)
        {
            //TODO - make this work
            return RedirectToAction("Index", "Home");
        }
    }
}
