using Blog.Library.Models;
using System.Collections.Generic;

namespace Blog.Library.DataProcessors
{
    public interface IPostProcessor
    {
        void CreatePost(string title, string content, int categoryId);
        List<PostModel> LoadPosts();
        List<PostModel> LoadPostById(int postId);
        void DeletePost(int postId);
    }
}