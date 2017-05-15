using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitMe.Models
{
    public class User
    {
        [Required(ErrorMessage = "You must provide your first name")]
        [Display(Name = "User name")]
        public string UName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string UPassword { get; set; }

        [Required(ErrorMessage = "You must provide your email address")]
        [Display(Name = "E-Mail address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string UEmail { get; set; }

        [Required(ErrorMessage = "You must provide your address")]
        [Display(Name = "Address")]
        public string UAdress { get; set; }

    }
}