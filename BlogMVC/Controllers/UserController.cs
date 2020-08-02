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
    public class UserController : Controller
    {
        private readonly IUserProcessor _userProcessor;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserProcessor userProcessor, IHttpContextAccessor httpContextAccessor)
        {
            _userProcessor = userProcessor;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult ManageUserData()
        {
            if (User.Identity.IsAuthenticated) //TODO - make this work
            {
                var load = _userProcessor.LoadUserInfo(_httpContextAccessor.HttpContext.
                    User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefault();

                if (load != null)
                {
                    UserModel user = new UserModel
                    {
                        Id = load.Id,
                        FirstName = load.FirstName,
                        EmailAddress = load.EmailAddress
                    };
                    return View(user);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult ManageUserData(UserModel model)
        {
            var load = _userProcessor.LoadUserInfo(_httpContextAccessor.HttpContext.
                    User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefault();

            if (load ==  null)
            {
                string id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                string emailAddress = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                bool newUser = true;
                _userProcessor.CreateUserInfo(id, model.FirstName, emailAddress, newUser);
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                string id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                string emailAddress = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                bool newUser = false;
                _userProcessor.CreateUserInfo(id, model.FirstName, emailAddress, newUser);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
