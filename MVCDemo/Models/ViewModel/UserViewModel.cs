using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Models.ViewModel
{
    public class UserViewModel
    {


        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [Remote("CheckPassword","Home",ErrorMessage ="error")]
        public string Password { get; set; }
        [Required]
       
        public string Usertype { get; set; }
        [Required]
        public string Fullname { get; set; }
    }
}