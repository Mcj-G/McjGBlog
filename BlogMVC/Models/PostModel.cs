using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMVC.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        [Display(Name = "Author:")]
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Created:")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Categoty:")]
        public int CategoryId { get; set; }

        public List<CategoryModel> CategoryList { get; set; } // TODO - try it out
    }
}
