using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext appDbContext;

        public BookController(AppDbContext db)
        {
            appDbContext = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> books = appDbContext.Books;
            return View(books);
        }
    }
}
