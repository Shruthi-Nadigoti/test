using Epam.Elevator.Business.Master;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Models.Master;
using Epam.Elevator.Presentation.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElevatorCoreModel = Epam.Elevator.Models.Master;

namespace Epam.Elevator.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
            List<ElevatorCoreModel.Elevator> elevatorList = elevatorBusiness.GetElevators();
            List<Floor> floorList = floorBusiness.GetFloors();
            List<ElevatorModel> elevatorModelList = new List<ElevatorModel>();
            foreach (ElevatorCoreModel.Elevator elevator in elevatorList)
            {
                ElevatorModel elevatorModel = new ElevatorModel
                {
                    ElevatorId=elevator.ElevatorId,
                    ElevatorName=elevator.ElevatorName,
                    FloorDuration=elevator.FloorDuration,
                    MainStatus= (Enums.MainStatus)Enum.Parse(typeof(Enums.MainStatus), lookupBusiness.GetLookupValue(elevator.MainStatusId)),
                    MaxWeight=elevator.MaxWeight
                };
                elevatorModelList.Add(elevatorModel);

            }
            List<FloorModel> floorModelList = new List<FloorModel>();
            foreach (Floor floor in floorList)
            {
                FloorModel floorModel = new FloorModel
                {
                    FloorId=floor.FloorId,
                    FloorName=floor.FloorName,
                    CreatedDate=floor.CreatedDate,
                    CreatedByUserId=floor.CreatedByUserId,
                    ModifiedByUserId=floor.ModifiedByUserId,
                    ModifiedDate=floor.ModifiedDate
                };
                floorModelList.Add(floorModel);

            }
            ViewBag.elevatorList = elevatorModelList;
            ViewBag.floorList = floorModelList;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}