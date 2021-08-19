using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly AppDbContext appDbContext;


        public AdminController( AppDbContext db)
        {
            appDbContext = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string pass)
        {

            if (username != null && pass != null && username.ToLower() == "admin" && pass == "pass")
                return RedirectToAction("ManageBooks");
            return View("~/Views/Admin/Index.cshtml");
        }

        public IActionResult ManageBooks()
        {
            return View(appDbContext.Books);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(String title,String author,String genre,String copies,String image)
        {
            Book book = new Book(title,author,genre,int.Parse(copies),image);
            book.Title = title;
            appDbContext.Add(book);
            appDbContext.SaveChanges();
            return RedirectToAction("ManageBooks");

        }
        public IActionResult AddCopy(int Id)
        {
            Book book = appDbContext.Books.FirstOrDefault(x => x.Id == Id);
            book.NumberofCopies++;
            appDbContext.SaveChanges();
            return RedirectToAction("ManageBooks");
        }

        public IActionResult DeleteCopy(int Id)
        {
            Book book = appDbContext.Books.FirstOrDefault(x => x.Id == Id);
            book.NumberofCopies--;
            if (book.NumberofCopies == 0)
                appDbContext.Remove(book);
            appDbContext.SaveChanges();
            return RedirectToAction("ManageBooks");
        }
    }
}
