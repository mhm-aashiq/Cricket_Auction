using Cricket_Auction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;



namespace Cricket_Auction.Controllers
{
    //[Route("Player")]
    public class BE_DashController : Controller
    {
        // private readonly ILogger<BE_DashController> _logger;

        
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public Admin Admin { get; set; }

        public BE_DashController(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public ActionResult Index()
        {
            ViewBag.Player = _db.Player.ToList();
            ViewBag.TeamOwner = _db.TeamOwner.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }


        //[Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password, Admin objUser)
        {
            var obj = _db.Admin.Where(p => p.Username.Equals(objUser.Username) && p.Password.Equals(objUser.Password)).FirstOrDefault();
            if (obj != null )
            {

                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Password", Password);
                //Session["UserName"] = obj.UserName.ToString();
                return RedirectToAction("Index");
            }
            else
            {


                // return RedirectToAction(nameof(Index), "BE_Dash", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Inserted Successfully" });
                
                return View();
            }
        }

        //public IActionResult Logout()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            
            return RedirectToAction("Login");
        }


    }
}

