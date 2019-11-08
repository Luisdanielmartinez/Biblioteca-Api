using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.ViewModel
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [Display(Name="First Name")]
        public string FisrtName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
