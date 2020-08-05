using Blog.Library.Models;
using System.Collections.Generic;

namespace Blog.Library.DataProcessors
{
    public interface ICommentProcessor
    {
        void CreateComment(int postId, string userId, string content);
        List<CommentDisplayModel> LoadComments(int postId);
    }
}