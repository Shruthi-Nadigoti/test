using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.Elevator.Business.Master;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Models.Master;

namespace Epam.Elevator.Presentation.Controllers
{
    public class FloorController : Controller
    {
        // GET: Floor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Floor/Details/5
        public ActionResult Details(int id)
        {
            FloorBusiness FloorBusiness = new FloorBusiness(new FloorDataAccess());
            List<Floor> floorList = FloorBusiness.GetFloors();
            return View(floorList);
        }

        // GET: Floor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Floor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                FloorBusiness FloorBusiness = new FloorBusiness(new FloorDataAccess());
                Floor floor = new Floor();
                // string iString = "2005-05-05 22:12 PM";
                // DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);
                FloorBusiness.Create(floor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Floor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Floor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                FloorBusiness FloorBusiness = new FloorBusiness(new FloorDataAccess());
                Floor floor = new Floor();
                // string iString = "2005-05-05 22:12 PM";
                // DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);
                FloorBusiness.Update(floor.FloorId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Floor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Floor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                FloorBusiness FloorBusiness = new FloorBusiness(new FloorDataAccess());
                Floor Floor = new Floor();
                // string iString = "2005-05-05 22:12 PM";
                // DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);
                FloorBusiness.Delete(Floor.FloorId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
