using CRUDWeb.Data;
using CRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDWeb.Controllers

{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Transactions obj)
        {
            if (ModelState.IsValid)
            {
                //string strCardNumber = obj.CardNumber;
                //strCardNumber = strCardNumber.Substring(0, 4) + "********" + strCardNumber.Substring(12, 4);
                //obj.CardNumber = strCardNumber;
                _context.Transactions.Add(obj);
                _context.SaveChanges();
                TempData["Success"] = "Transaction Successful.";
                return RedirectToAction("Index");

            }
            return View(obj);
        }


            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
