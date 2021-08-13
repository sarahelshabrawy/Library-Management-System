using Library.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
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
    }
}
