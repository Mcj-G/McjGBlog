namespace Blog.Library.DataProcessors
{
    public interface ICommentProcessor
    {
        void CreateComment(int postId, string userId, string content);
    }
}