using Epam.Elevator.Business.Master;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Models.Master;
using Epam.Elevator.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.Elevator.Presentation.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
       
        // POST: LogIn/Create
        [HttpPost]
        public ActionResult Index(LogInModel logInModel)
        {
            try
            {
                UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
                User user = userBusiness.IsValidUser(logInModel.EmailId,logInModel.Password);

                // TODO: Add insert logic here

                return RedirectToAction("Edit");
            }
            catch
            {
                return View();
            }
        }

        // GET: LogIn/Edit/5
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: LogIn/Edit/5
        [HttpPost]
        public ActionResult ChangePassword(FormCollection collection)
        {
            try
            {
                Int32 UserId = 1;//Session["UserId"];
                String Password = collection["OldPassword"];
                String NewPassword = collection["NewPassword"];
                UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
                //User user = userBusiness.ChangePassword(UserId,Password,NewPassword);
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LogIn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LogIn/Delete/5
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
