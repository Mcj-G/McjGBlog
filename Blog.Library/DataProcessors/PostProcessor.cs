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

        public List<PostDisplayModel> LoadPosts()
        {
            return _sql.LoadData<PostDisplayModel, dynamic>("dbo.spPost_GetAll", new { }, "SQLData");
        }

        public List<PostDisplayModel> LoadPostById(int postId)
        {
            return _sql.LoadData<PostDisplayModel, dynamic>("dbo.spPost_GetById", new { Id = postId }, "SQLData");
        }

        public void EditPost(int postId, string title, string content)
        {
            _sql.SaveData("dbo.spPost_Update", new { Id = postId, Title = title, Content = content }, "SQLData");
        }

        public void DeletePost(int postId)
        {
            _sql.DeleteData("dbo.spPost_Delete", new { Id = postId }, "SQLData");
        }
    }
}
