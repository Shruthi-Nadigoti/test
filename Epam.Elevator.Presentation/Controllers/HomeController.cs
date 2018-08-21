using Epam.Elevator.Business.Master;
using Epam.Elevator.DataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Elevator.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ElevatorBusiness elevatorBusiness = new ElevatorBusiness(new ElevatorDataAccess());
            FloorBusiness floorBusiness = new FloorBusiness(new FloorDataAccess());
            ViewBag.elevatorList = elevatorBusiness.GetElevators();
            ViewBag.floorList = floorBusiness.GetFloors();
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