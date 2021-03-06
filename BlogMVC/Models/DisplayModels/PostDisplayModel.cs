﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMVC.Models.DisplayModels
{
    public class PostDisplayModel
    {
        public int Id { get; set; }

        [Display(Name = "Author:")]
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Created:")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Categoty:")]
        public string CategoryName { get; set; }
        public List<CommentDisplayModel> Comments { get; set; }
    }
}
