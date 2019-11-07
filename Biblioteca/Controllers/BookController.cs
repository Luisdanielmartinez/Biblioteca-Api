using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Biblioteca.Reporsitory;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class BookController : Controller
    {
        private IReporsitory<Author> _repoAuthor;
        private IReporsitory<Book> _repoBook;
        public BookController(IReporsitory<Author>repoAuthor,IReporsitory<Book>repoBook)
        {
            _repoAuthor = repoAuthor;
            _repoBook = repoBook;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}