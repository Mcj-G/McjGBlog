﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Library.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
