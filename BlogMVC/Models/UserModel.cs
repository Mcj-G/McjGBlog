using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMVC.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        
        [Display(Name = "First Name")]
        //[Required(ErrorMessage = "Please, enter your name.")]
        public string FirstName { get; set; }

        [Display(Name = "Email Address")]
        //[Required(ErrorMessage = "Please, enter your email address.")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Please, enter a valid email address")]
        //[EmailAddress]
        public string EmailAddress { get; set; }
    }
}
