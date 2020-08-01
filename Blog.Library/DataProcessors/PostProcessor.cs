using Blog.Library.DataAccess;
using Blog.Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Blog.Library.DataProcessors
{
    public class PostProcessor : IPostProcessor
    {
        private readonly ISqlDataAccess _sql;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostProcessor(ISqlDataAccess sql, IHttpContextAccessor httpContextAccessor)
        {
            _sql = sql;
            _httpContextAccessor = httpContextAccessor;
        }
        public void CreatePost(string title,
                               string content,
                               int categoryId)
        {
            PostModel data = new PostModel
            {
                AuthorId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Title = title,
                Content = content,
                CreatedDate = DateTime.Now,
                CategoryId = categoryId
            };

            _sql.SaveData("dbo.spPost_Insert", data, "SQLData");
        }

        public List<PostModel> LoadPosts()
        {
            return _sql.LoadData<PostModel, dynamic>("dbo.spPost_GetAll", new { }, "SQLData");
        }
    }
}
