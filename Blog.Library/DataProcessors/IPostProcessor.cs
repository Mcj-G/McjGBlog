using Blog.Library.Models;
using System.Collections.Generic;

namespace Blog.Library.DataProcessors
{
    public interface IPostProcessor
    {
        void CreatePost(string title, string content, int categoryId);
        List<PostDisplayModel> LoadPosts();
        List<PostDisplayModel> LoadPostById(int postId);
        void EditPost(int postId, string title, string content);
        void DeletePost(int postId);
    }
}