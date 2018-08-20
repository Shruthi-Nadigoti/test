using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Business.Master;
using ElevatorModel = Epam.Elevator.Models.Master;
namespace Epam.Elevator.Presentation.Controllers
{
    public class ElevatorController : Controller
    {
        // GET: Elevator
        public ActionResult Index()
        {
            return View();
        }

        // GET: Elevator/Details
        public ActionResult Details()
        {
            ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            List<ElevatorModel.Elevator> elevatorList = elevatorBusiness.GetElevators();
            return View(elevatorList);
        }

        // GET: Elevator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Elevator/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
                ElevatorModel.Elevator elevator = new ElevatorModel.Elevator();
                // string iString = "2005-05-05 22:12 PM";
                // DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);
                elevatorBusiness.Create(elevator);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Elevator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Elevator/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
                ElevatorModel.Elevator elevator = new ElevatorModel.Elevator();
                // string iString = "2005-05-05 22:12 PM";
                // DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);
                elevatorBusiness.Update(elevator);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Elevator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Elevator/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
                ElevatorModel.Elevator elevator = new ElevatorModel.Elevator();
                // string iString = "2005-05-05 22:12 PM";
                // DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);
                elevatorBusiness.Delete(elevator.ElevatorId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
