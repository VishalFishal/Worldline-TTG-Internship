using CRUDWeb.Data;
using CRUDWeb.Models;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CRUDWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Accounts obj)
        {
            if (ModelState.IsValid)
            {
                foreach (var dbObj in _db.Accounts)
                {
                    if (dbObj.Email == obj.Email)
                    {
                        if (dbObj.Password == obj.Password)
                            //Session["username"] = obj.Email;
                            return RedirectToAction("Index", "Home");
                    }

                }
                TempData["Error"] = "Email or password is incorrect.";
                return RedirectToAction("Index", obj);  
            }
            return RedirectToAction("Index", obj);
        }

        public IActionResult Register()
        { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
            public IActionResult RegisterSubmit(Accounts obj, string confirmPassword)
            {
            if (ModelState.IsValid)
            {
                if (confirmPassword == obj.Password)
                {
                    _db.Accounts.Add(obj);
                    _db.SaveChanges();
                    TempData["Success"] = "Registered Successfully.";
                    return RedirectToAction("Register");
                }
            }
            TempData["Error"] = "Passwords do not match.";
                return RedirectToAction("Register");
            }
        
    }
}
