using Blog.Library.DataAccess;
using Blog.Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Blog.Library.DataProcessors
{
    public class UserProcessor : IUserProcessor
    {
        private readonly ISqlDataAccess _sql;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProcessor(ISqlDataAccess sql, IHttpContextAccessor httpContextAccessor)
        {
            _sql = sql;
            _httpContextAccessor = httpContextAccessor;
        }
        public void CreateUserInfo(string id, string name, string emailAddress, bool newUser)
        {
            if (newUser)
            {
                UserModel data = new UserModel
                {
                    Id = id,
                    FirstName = name,
                    EmailAddress = emailAddress
                };

                _sql.SaveData("dbo.spUser_Insert", data, "SQLData"); 
            }
            else
            {
                UserModel data = new UserModel
                {
                    Id = id,
                    FirstName = name,
                    EmailAddress = emailAddress
                };

                _sql.SaveData("dbo.spUser_Update", data, "SQLData");
            }
        }

        public List<UserModel> LoadUserInfo(string id)
        {
            return _sql.LoadData<UserModel, dynamic>("dbo.spUser_GetById", new { id }, "SQLData");
        }
    }
}
