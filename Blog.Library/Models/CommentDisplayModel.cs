using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Library.Models
{
    public class CommentDisplayModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
