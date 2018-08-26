using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.Elevator.Business.Master;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Models.Master;
using Epam.Elevator.Presentation.Master;

namespace Epam.Elevator.Presentation.Controllers
{
    public class FloorController : Controller
    {
        // GET: Floor
        public ActionResult Index()
        {
            FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
            List<Floor> floorList = floorBusiness.GetFloors();
            List<FloorModel> floorModelList = new List<FloorModel>();
            foreach (Floor floor in floorList)
            {
                FloorModel floorModel = new FloorModel
                {
                    FloorId=floor.FloorId,
                    FloorName=floor.FloorName,
                    CreatedByUserId=floor.CreatedByUserId,
                    CreatedDate=floor.CreatedDate,
                    ModifiedByUserId=floor.ModifiedByUserId,
                    ModifiedDate=floor.ModifiedDate
                };
                floorModelList.Add(floorModel);

            }
            return View(floorModelList);
        }

        // GET: Floor/Details
        public ActionResult Details(int id)
        {
            FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
            Floor floor = floorBusiness.GetFloor(id);
            FloorModel FloorModel = new FloorModel
            {
                FloorId=floor.FloorId,
                FloorName=floor.FloorName,
                ModifiedDate=floor.ModifiedDate,
                ModifiedByUserId=floor.ModifiedByUserId,
                CreatedDate=floor.CreatedDate,
                CreatedByUserId=floor.CreatedByUserId
            };
            return View(FloorModel);
        }

        // GET: Floor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Floor/Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            //  try
            //  {               
            FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
            Floor floor = new Floor
            {
                FloorId = Convert.ToInt32(formCollection["FloorId"]),
                FloorName = Convert.ToString(formCollection["FloorName"]),
                CreatedByUserId = 1,// (int)Session["FloorId"];
                ModifiedByUserId = 2,// (int)Session["FloorId"];
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
            floorBusiness.Create(floor);
            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Floor/Edit/5
        public ActionResult Edit(int id)
        {
            FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
            Floor floor = floorBusiness.GetFloor(id);
            FloorModel floorModel = new FloorModel
            {
               FloorId=floor.FloorId,
               FloorName=floor.FloorName,
               CreatedByUserId=floor.CreatedByUserId,
               CreatedDate=floor.CreatedDate,
               ModifiedByUserId=floor.ModifiedByUserId,
               ModifiedDate=floor.ModifiedDate
            };
            return View(floorModel);
        }

        // POST: Floor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            //try
            //{
            // TODO: Add update logic here
            FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
            Floor floor = new Floor
            {
                CreatedByUserId = 1,// (int)Session["FloorId"];
                ModifiedByUserId = 2,// (int)Session["FloorId"];
                FloorId = id,
                FloorName = formCollection["FloorName"]
            };
            floorBusiness.Update(floor);
            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Floor/Delete/5
        public ActionResult Delete(int id)
        {
            FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
            Floor floor = floorBusiness.GetFloor(id);
            FloorModel FloorModel = new FloorModel
            {
                FloorId = floor.FloorId,
                FloorName = floor.FloorName,
                ModifiedDate = floor.ModifiedDate,
                ModifiedByUserId = floor.ModifiedByUserId,
                CreatedDate = floor.CreatedDate,
                CreatedByUserId = floor.CreatedByUserId
            };
            return View(FloorModel);
        }

        // POST: Floor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
                bool result = floorBusiness.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
