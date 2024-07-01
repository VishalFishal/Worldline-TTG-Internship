using CRUDWeb.Data;
using CRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWeb.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Transactions> objTransactionsList = _context.Transactions;
            return View(objTransactionsList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var objToBeDeleted = _context.Transactions.Find(id);
            if (objToBeDeleted != null)
            {
                _context.Transactions.Remove(objToBeDeleted);
                _context.SaveChanges();
                TempData["Success"] = "Transaction deleted.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error in deletion.";
             return NotFound();
        }


    }
}
