using Cricket_Auction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cricket_Auction.Controllers
{
    public class TrophyController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public Trophy Trophy { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        

        public TrophyController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public ActionResult ManageTrophy(ReturnModel data = null)
        {
            if (data == null || data.Model == null)
            {
                var Data = _db.trophies.ToList();
                return View(Data);
            }
            else
            {
                ViewBag.ReturnModel = data;
                return View();
            }
        }


        // GET: EmployeeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    Player Data = _db.trophies.include(i=>i.);
        //    return View(Data);
        //}

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
        public ActionResult Create(Trophy data)
        {
            try
            {
                if (data != null)
                {
                    _db.trophies.Add(data);
                    int result = _db.SaveChanges();
                    if (result > 0) return RedirectToAction(nameof(ManageTrophy), "Trophy", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Inserted Successfully" });
                    else return RedirectToAction(nameof(Create), "Trophy", new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Data Inserted Successfully", Model = data });
                }
                else
                    return RedirectToAction(nameof(ManageTrophy), "Trophy", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Data Captured", Model = new Trophy { } });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Create), "Trophy", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown" + er.Message });
            }
        }

        // GET: EmployeeController/Update/5
        public ActionResult Update(int id, ReturnModel data = null)
        {
            if (data == null || data.Model == null)
            {
                var records = _db.trophies.Find(id);
                if (records != null)
                    return View(records);
                else
                    return RedirectToAction(nameof(ManageTrophy), "Trophy", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found" });
            }
            else
                ViewBag.ReturnModel = data;
            return View(data.Model);


        }

        // POST: EmployeeController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, Trophy data)
        {
            try
            {
                if (data != null)
                {
                    _db.trophies.Update(data);
                    int result = await _db.SaveChangesAsync();
                    if (result > 0) return RedirectToAction(nameof(ManageTrophy), "Trophy", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Updated Successfully" });
                    else return RedirectToAction(nameof(Update), "Trophy", new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Record Update Failed", Model = data });
                }
                return RedirectToAction(nameof(Update), "Trophy", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found", Model = new Trophy { } });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Update), "Trophy", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown :" + er.Message });
            }
        }


    




        // EmployeeController/Delete/5
        public async Task<ActionResult<ReturnModel>> Delete(int id, Trophy data)
        {
            try
            {
                if (id > 0)
                {
                    data = _db.trophies.Find(id);
                    _db.trophies.Remove(data);
                    int result = await _db.SaveChangesAsync();
                    if (result > 0) return new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Record Removed Successfully" };
                    else return new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Record Removal Failed", Model = data };
                }
                return RedirectToAction(nameof(ManageTrophy), "Trophy", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found" });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(ManageTrophy), "Trophy", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown :" + er.Message });
            }
        }
    }
}
