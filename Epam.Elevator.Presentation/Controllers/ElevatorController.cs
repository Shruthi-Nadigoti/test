using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Business.Master;
using ElevatorCoreModel = Epam.Elevator.Models.Master;
using Epam.Elevator.Presentation.Master;
namespace Epam.Elevator.Presentation.Controllers
{
    public class ElevatorController : Controller
    {
        // GET: Elevator
        public ActionResult Index()
        {
            ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            List<ElevatorCoreModel.Elevator> elevatorList = elevatorBusiness.GetElevators();
            List<ElevatorModel> elevatorModelList = new List<ElevatorModel>();
            foreach (var elevator in elevatorList)
            {
                ElevatorModel elevatorModel = new ElevatorModel
                {
                    ElevatorId = elevator.ElevatorId,
                    ElevatorName = elevator.ElevatorName,
                    FloorDuration = elevator.FloorDuration,
                    MaxWeight = elevator.MaxWeight,
                    MainStatus = (Enums.MainStatus)Enum.Parse(typeof(Enums.MainStatus), lookupBusiness.GetLookupValue(elevator.MainStatusId)),
                };
                elevatorModelList.Add(elevatorModel);

            }
            return View(elevatorModelList);
        }

        // GET: Elevator/Details
        public ActionResult Details(int id)
        {
            ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            ElevatorCoreModel.Elevator elevator = elevatorBusiness.GetElevator(id);
            ElevatorModel elevatorModel = new ElevatorModel
            {

                ElevatorName = elevator.ElevatorName,
                CreatedByUserId = elevator.CreatedByUserId,
                MainStatus = (Enums.MainStatus)Enum.Parse(typeof(Enums.MainStatus), lookupBusiness.GetLookupValue(elevator.MainStatusId)),
                ModifiedByUserId = elevator.ModifiedByUserId,
                ModifiedDate = elevator.ModifiedDate,
                MaxWeight = elevator.MaxWeight,
                FloorDuration = elevator.FloorDuration,
                CreatedDate = elevator.CreatedDate,
                ElevatorId = elevator.ElevatorId
            };
            return View(elevatorModel);
        }

        // GET: Elevator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Elevator/Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            //  try
            //  {               
            ElevatorBusiness ElevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            ElevatorCoreModel.Elevator elevator = new ElevatorCoreModel.Elevator
            {

                CreatedByUserId = 1,// (int)Session["ElevatorId"];
                ModifiedByUserId = 2,// (int)Session["ElevatorId"];
                ElevatorName = formCollection["ElevatorName"],
                FloorDuration = Convert.ToInt32(formCollection["FloorDuration"]),
                MaxWeight = Convert.ToInt32(formCollection["MaxWeight"]),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                MainStatusId = lookupBusiness.GetLookupId("MainStatus", formCollection["MainStatus"]),
            };
            ElevatorBusiness.Create(elevator);
            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Elevator/Edit/5
        public ActionResult Edit(int id)
        {
            ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            ElevatorCoreModel.Elevator elevator = elevatorBusiness.GetElevator(id);
            ElevatorModel elevatorModel = new ElevatorModel
            {
                ElevatorName = elevator.ElevatorName,
                CreatedByUserId = elevator.CreatedByUserId,
                MainStatus = (Enums.MainStatus)Enum.Parse(typeof(Enums.MainStatus), lookupBusiness.GetLookupValue(elevator.MainStatusId)),
                ModifiedByUserId = elevator.ModifiedByUserId,
                ModifiedDate = elevator.ModifiedDate,
                MaxWeight = elevator.MaxWeight,
                FloorDuration = elevator.FloorDuration,
                CreatedDate = elevator.CreatedDate,
                ElevatorId = elevator.ElevatorId
            };
            return View(elevatorModel);
        }

        // POST: Elevator/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            //try
            //{
            // TODO: Add update logic here
            ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            ElevatorCoreModel.Elevator elevator = new ElevatorCoreModel.Elevator
            {
                CreatedByUserId = 1,// (int)Session["UserId"];
                ModifiedByUserId = 2,// (int)Session["UserId"];
                ElevatorName = formCollection["ElevatorName"],
                FloorDuration = Convert.ToInt32(formCollection["FloorDuration"]),
                MaxWeight = Convert.ToInt32(formCollection["MaxWeight"]),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                MainStatusId = lookupBusiness.GetLookupId("MainStatus", formCollection["MainStatus"])
            };
            elevatorBusiness.Update(elevator);
            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Elevator/Delete/5
        public ActionResult Delete(int id)
        {
            ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            ElevatorCoreModel.Elevator elevator = elevatorBusiness.GetElevator(id);
            ElevatorModel elevatorModel = new ElevatorModel
            {
                ElevatorName = elevator.ElevatorName,
                FloorDuration = elevator.FloorDuration,
                CreatedByUserId = elevator.CreatedByUserId,
                ModifiedByUserId = elevator.ModifiedByUserId,
                MainStatus = (Enums.MainStatus)Enum.Parse(typeof(Enums.MainStatus), lookupBusiness.GetLookupValue(elevator.MainStatusId)),
                MaxWeight = elevator.MaxWeight,
                ElevatorId = elevator.ElevatorId,
                CreatedDate = elevator.CreatedDate,
                ModifiedDate = elevator.ModifiedDate

            };
            return View(elevatorModel);
        }

        // POST: Elevator/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
                bool result = elevatorBusiness.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
