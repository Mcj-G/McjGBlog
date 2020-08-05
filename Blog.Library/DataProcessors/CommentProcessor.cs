using Blog.Library.DataAccess;
using Blog.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Library.DataProcessors
{
    public class CommentProcessor : ICommentProcessor
    {
        private readonly ISqlDataAccess _sql;

        public CommentProcessor(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public void CreateComment(int postId, string userId, string content)
        {
            CommentModel model = new CommentModel
            {
                PostId = postId,
                UserId = userId,
                Content = content,
                CreatedDate = DateTime.Now
            };

            _sql.SaveData("dbo.spComment_Insert", model, "SQLData");
        }

        public List<CommentDisplayModel> LoadComments(int postId)
        {
            return _sql.LoadData<CommentDisplayModel, dynamic>("dbo.spComment_GetAllByPostId", new { PostId = postId }, "SQLData");
        }

    }
}
