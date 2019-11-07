﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Biblioteca.ViewModel
{
    public class AuthorBookViewModel
    {
        public int Id { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
