﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PerfumeStore_BrandNCountry.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Please enter user name")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string password { get; set; }
        public bool isRemember { get; set; }
    }
}