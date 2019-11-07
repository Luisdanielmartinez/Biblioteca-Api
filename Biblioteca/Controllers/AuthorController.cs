using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Biblioteca.Reporsitory;
using Biblioteca.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class AuthorController : Controller
    {
        private IReporsitory<Book> _repoBook;
        private IReporsitory<Author> _repoAuthor;
        public AuthorController(IReporsitory<Book>repoBook,IReporsitory<Author>repoAuthor)
        {
            _repoAuthor = repoAuthor;
            _repoBook = repoBook;
        }
        public IActionResult Index()
        {
            List<AuthorListingViewModel> model = new List<AuthorListingViewModel>();
            _repoAuthor.GetAllData().ToList().ForEach(a =>
            {
                AuthorListingViewModel author = new AuthorListingViewModel
                {
                    Id = a.Id,
                    Name = $"{a.FirstName} {a.LastName}",
                    Email = a.Email
                };
                //aqui me busca el total de los libros de ese author
                author.TotalBook = _repoBook.GetAllData().Count(x => x.AuthorId == a.Id);
                //aqui se agrega a el model view de listing para la vista
                model.Add(author);
            });
            return View("Index",model);
        }
        [HttpGet]
        public PartialViewResult AddAuthor()
        {
            AuthorBookViewModel model = new AuthorBookViewModel();
            return PartialView("AddAuthor",model);
        }
        [HttpPost]
        public ActionResult AddAuthor(AuthorBookViewModel model)
        {
            try
            {
                Author author = new Author {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    ModifiedDate=DateTime.UtcNow,
                    Books=new List<Book>
                    {
                        new Book
                        {
                            Name=model.BookName,
                            ISBN=model.ISBN,
                            Publisher=model.Publisher,
                            IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                            ModifiedDate=DateTime.UtcNow
                        }
                    }
                    
                };
                _repoAuthor.Insert(author);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("error"+ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}