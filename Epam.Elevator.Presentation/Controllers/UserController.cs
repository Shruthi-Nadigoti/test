using Epam.Elevator.Business.Master;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Models;
using Epam.Elevator.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Elevator.Presentation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details()
        {
            //List<User> x = new List<User>() {
            //new User{ FirstName="shruthi",LastName="Nadigoti",UserId=1},
            //new User{ FirstName="shravya",LastName="Nadigoti",UserId=2},
            //new User{ FirstName="shr",LastName="Nadigoti",UserId=3}};
            UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
            List<User> userList = userBusiness.GetUsers();
            return View(userList);
        }
        public ActionResult Get(int id)
        {
            try
            {
                
                return View();
            }
            catch
            {
                return View();
            }
        }
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
          //  try
          //  {               
                UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
                User user = new User();
                user.CreatedByUserId = 1;// (int)Session["UserId"];
                user.ModifiedByUserId = 2;// (int)Session["UserId"];
                user.Address = formCollection["Address"];
                user.EmaidId = formCollection["EmailId"];
                user.FirstName = formCollection["FirstName"];
                user.LastName = formCollection["LastName"];
                user.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), formCollection["StudentGender"]);
                user.Password = formCollection["Password"];

               // string iString = "2005-05-05 22:12 PM";
               // DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", null);
                userBusiness.Create(user);
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(new User { FirstName = "shruthi", LastName = "Nadigoti", UserId = 1 });
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
