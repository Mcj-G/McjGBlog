using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMVC.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
