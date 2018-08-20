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
            UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
            List<User> userList = userBusiness.GetUsers();
            return View(userList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
            User user = userBusiness.Get(id);
            return View(user);
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
                user.EmailId = formCollection["EmailId"];
                user.FirstName = formCollection["FirstName"];
                user.LastName = formCollection["LastName"];
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.DateOfBirth = DateTime.Now;
                user.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), formCollection["Gender"]);
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
            UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
            User user = userBusiness.Get(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            //try
            //{
                // TODO: Add update logic here
                UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
                User user = new User();
                user.CreatedByUserId = 1;// (int)Session["UserId"];
                user.ModifiedByUserId = 2;// (int)Session["UserId"];
                user.Address = formCollection["Address"];
                user.EmailId = formCollection["EmailId"];
                user.FirstName = formCollection["FirstName"];
                user.LastName = formCollection["LastName"];
                user.Password = formCollection["Password"];
                user.UserId = id;
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.DateOfBirth = DateTime.Now;
                user.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), formCollection["Gender"]);
                userBusiness.Update(user);
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {

            UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
            User user = userBusiness.Get(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
                bool result = userBusiness.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
