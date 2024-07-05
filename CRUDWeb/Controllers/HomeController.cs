using CRUDWeb.Data;
using CRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using System.Net.Sockets;
using System.Net.Http;
using System.Text;

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
                string strCardNumber = obj.CardNumber;
                strCardNumber = strCardNumber.Substring(0, 4) + "********" + strCardNumber.Substring(12, 4);
                obj.CardNumber = strCardNumber;
                _context.Transactions.Add(obj);
                _context.SaveChanges();
                TempData["Success"] = "Transaction Successful.";

                //using (var client = new HttpClient())
                //{}

                /*using var client = new TcpClient();
                var hostname = "txuat.mrlpay.com";
                int port = 3606;
                client.Connect(hostname, port);
                using(NetworkStream networkStream = client.GetStream()) {
                    var message = "From TCP";
                    Console.WriteLine(message);
                    using(var reader = new StreamReader(networkStream, Encoding.UTF8)) {
                        byte[] bytes = Encoding.UTF8.GetBytes(message);
                        networkStream.Write(bytes, 0, bytes.Length);
                        Console.WriteLine(reader.ReadToEnd());
                }
                }*/


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

