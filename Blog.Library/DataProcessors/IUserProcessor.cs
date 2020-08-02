using Blog.Library.Models;
using System.Collections.Generic;

namespace Blog.Library.DataProcessors
{
    public interface IUserProcessor
    {
        void CreateUserInfo(string id, string name, string emailAddress, bool newUser);
        List<UserModel> LoadUserInfo(string id);
    }
}