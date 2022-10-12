using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cricket_Auction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Cricket_Auction.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IHttpContextAccessor _context;
        private readonly ApplicationDbContext _db;
        [BindProperty]


        public Player Player { get; set; }

        public PlayerController(ApplicationDbContext db, IHttpContextAccessor context)
        {
            _db = db;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Manage Players
        public ActionResult Manage(ReturnModel data = null)
        {
            if (data == null || data.Model == null)
            {
                var Data = _db.Player.ToList();
                return View(Data);
            }
            else
            {
                ViewBag.ReturnModel = data;
                return View();
            }
        }


        //// GET: EmployeeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    Player Data = _db.Player.Find(id);
        //    return View(Data);
        //}

        // GET: PlayerController/Details/5
        public ActionResult UserDashboard(string username)
        {
            //Player Data = _db.Player.Find(id);
            //var item = _db.Player.Where(s => s.Username == username).ToList().FirstOrDefault();
            ViewBag.Player= _db.Player.ToList();
           
            
            var PlayerBag = "@ViewBag.Player";
            var obj = HttpContext.Session.GetString("Username");
           
            //    return View(data);
            if (obj == PlayerBag)
            {
                //return RedirectToAction(nameof(Login), "Player", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "Try again", Model = new Player { } });
               
                return View();
            }

            return View();
           // var item = _db.Player.Where(s => s.Username == username).ToList();






        }

       

        // GET: EmployeeController/Create
        public ActionResult Create(ReturnModel data = null)
        {
            if (data == null || data.Model == null)
                return View();
            else
                ViewBag.ReturnModel = data;
            return View(data.Model);
        }

 

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Player data)
        {
            try
            {
                if (data != null)
                {
                    _db.Player.Add(data);
                    int result = _db.SaveChanges();
                    if (result > 0) return RedirectToAction(nameof(Manage), "Player", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Inserted Successfully" });
                    else return RedirectToAction(nameof(Create), "Player", new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Data Inserted Successfully", Model = data });
                }
                else
                    return RedirectToAction(nameof(Manage), "Player", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Data Captured", Model = new Player { } });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Create), "Player", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown" + er.Message });
            }
        }

        // GET: EmployeeController/Update/5
        public ActionResult Update(int id, ReturnModel data = null)
        {
            if (data == null || data.Model == null)
            {
                var records = _db.Player.Find(id);
                if (records != null)
                    return View(records);
                else
                    return RedirectToAction(nameof(Manage), "Player", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found" });
            }
            else
                ViewBag.ReturnModel = data;
            return View(data.Model);


        }

        // POST: EmployeeController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, Player data)
        {
            try
            {
                if (data != null)
                {
                    _db.Player.Update(data);
                    int result = await _db.SaveChangesAsync();
                    if (result > 0) return RedirectToAction(nameof(Manage), "Player", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Updated Successfully" });
                    else return RedirectToAction(nameof(Update), "Player", new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Record Update Failed", Model = data });
                }
                return RedirectToAction(nameof(Update), "Player", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found", Model = new Player { } });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Update), "Player", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown :" + er.Message });
            }
        }


        public ActionResult Login()
        {
            return View();
        }
        //public ActionResult UserDashboard()
        //{
        //    return View();
        //}


        //[Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password, Player objUser)
        {
            var obj = _db.Player.Where(p => p.Username.Equals(objUser.Username) && p.Password.Equals(objUser.Password)).FirstOrDefault();
            if (obj != null)
            {

                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Password", Password);
               //var name =  HttpContext.Session.GetString("Username");
                //Session["UserName"] = obj.UserName.ToString();
                return RedirectToAction("UserDashboard");
            }
            else
            {


                // return RedirectToAction(nameof(Index), "BE_Dash", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Inserted Successfully" });
                return View(new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Wrong" });
            }
        }




        // EmployeeController/Delete/5
        public async Task<ActionResult<ReturnModel>> Delete(int id, Player data)
        {
            try
            {
                if (id > 0)
                {
                    data =_db.Player.Find(id);
                    _db.Player.Remove(data);
                    int result = await _db.SaveChangesAsync();
                    if (result > 0) return new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Record Removed Successfully" };
                    else return new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Record Removal Failed", Model = data };
                }
                return RedirectToAction(nameof(Manage), "Player", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found" });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Manage), "Player", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown :" + er.Message });
            }
        }
    }
}
