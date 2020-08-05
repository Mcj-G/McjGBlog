using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMVC.Models.DisplayModels
{
    public class CommentDisplayModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        [Display(Name = "Author:")]
        public string UserName { get; set; }
        public string Content { get; set; }

        [Display(Name = "Created:")]
        public DateTime CreatedDate { get; set; }
    }
}
