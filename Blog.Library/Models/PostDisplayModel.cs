using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Library.Models
{
    public class PostDisplayModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryName { get; set; }
        public List<CommentDisplayModel> Comments { get; set; }
    }
}
