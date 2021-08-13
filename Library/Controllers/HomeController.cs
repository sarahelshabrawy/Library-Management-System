using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext appDbContext;

  
        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            appDbContext = db;
        }

        public IActionResult Index(string keywoard)
        {
            IEnumerable<Book> books = appDbContext.Books;
            return View(books.Where(x => keywoard == null || x.Title.ToLower().Contains(keywoard.ToLower()) 
            || x.Genre.ToLower().Contains(keywoard.ToLower()) || x.Author.ToLower().Contains(keywoard.ToLower())));
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
