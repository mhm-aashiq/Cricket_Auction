using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cricket_Auction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cricket_Auction.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public Team Team { get; set; }

        public TeamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }




        public ActionResult ManageTeam(ReturnModel data = null)
        {
            if (data == null || data.Model == null)
            {
                var Data = _db.Team.ToList();
                return View(Data);
            }
            else
            {
                ViewBag.ReturnModel = data;
                return View();
            }
        }


        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            Team Data = _db.Team.Find(id);
            return View(Data);
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
        public ActionResult Create(Team data)
        {
            try
            {
                if (data != null)
                {
                    _db.Team.Add(data);
                    int result = _db.SaveChanges();
                    if (result > 0) return RedirectToAction(nameof(ManageTeam), "Team", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Inserted Successfully" });
                    else return RedirectToAction(nameof(Create), "Team", new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Data Inserted Successfully", Model = data });
                }
                else
                    return RedirectToAction(nameof(ManageTeam), "Team", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Data Captured", Model = new Team { } });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Create), "Team", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown" + er.Message });
            }
        }

        // GET: EmployeeController/Update/5
        public ActionResult Update(int id, ReturnModel data = null)
        {
            if (data == null || data.Model == null)
            {
                var records = _db.Team.Find(id);
                if (records != null)
                    return View(records);
                else
                    return RedirectToAction(nameof(ManageTeam), "Team", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found" });
            }
            else
                ViewBag.ReturnModel = data;
            return View(data.Model);


        }

        // POST: EmployeeController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, Team data)
        {
            try
            {
                if (data != null)
                {
                    _db.Team.Update(data);
                    int result = await _db.SaveChangesAsync();
                    if (result > 0) return RedirectToAction(nameof(ManageTeam), "Team", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Updated Successfully" });
                    else return RedirectToAction(nameof(Update), "Team", new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Record Update Failed", Model = data });
                }
                return RedirectToAction(nameof(Update), "TeamOwner", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found", Model = new Team { } });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Update), "TeamOwner", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown :" + er.Message });
            }
        }


        //public ActionResult Login()
        //{
        //    return View();
        //}


        ////[Route("Login")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(string Username, string Password, Team objUser)
        //{
        //    var obj = _db.TeamOwner.Where(p => p.Username.Equals(objUser.Username) && p.Password.Equals(objUser.Password)).FirstOrDefault();
        //    if (Username != null && Password != null && Username.Equals(objUser.Username) && Password.Equals(objUser.Username))
        //    {
        //        HttpContext.Session.SetString("Username", Username);
        //        return View("UserDashboard");

        //    }
        //    else
        //    {
        //        ViewBag.error = "Invalid Account";
        //        return View("Index");
        //    }
        //}




        // EmployeeController/Delete/5
        public async Task<ActionResult<ReturnModel>> Delete(int id, Team data)
        {
            try
            {
                if (id > 0)
                {
                    data = _db.Team.Find(id);
                    _db.Team.Remove(data);
                    int result = await _db.SaveChangesAsync();
                    if (result > 0) return new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Record Removed Successfully" };
                    else return new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Record Removal Failed", Model = data };
                }
                return RedirectToAction(nameof(ManageTeam), "Team", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found" });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(ManageTeam), "Team", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown :" + er.Message });
            }
        }
    }
    }
