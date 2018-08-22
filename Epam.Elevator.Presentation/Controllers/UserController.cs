using Epam.Elevator.Business.Master;
using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Models;
using Epam.Elevator.Models.Master;
using Epam.Elevator.Presentation.Master;
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
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            List<User> userList = userBusiness.GetUsers();
            List<UserModel> userModelList = new List<UserModel>();
            foreach (User user in userList)
            {
                UserModel userModel = new UserModel
                {
                    Address = user.Address,
                    CreatedByUserId = user.CreatedByUserId,
                    CreatedDate = user.CreatedDate,
                    DateOfBirth = user.DateOfBirth,
                    EmailId = user.EmailId,
                    FirstName = user.FirstName,
                    Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), lookupBusiness.GetLookupValue(user.GenderId)),
                    LastName = user.LastName,
                    ModifiedByUserId = user.ModifiedByUserId,
                    ModifiedDate = user.ModifiedDate,
                    Password = user.Password,
                    UserId = user.UserId
                };
                userModelList.Add(userModel);

            }
            return View(userModelList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            User user = userBusiness.Get(id);
            UserModel userModel = new UserModel
            {
                Address = user.Address,
                CreatedByUserId = user.CreatedByUserId,
                CreatedDate = user.CreatedDate,
                DateOfBirth = user.DateOfBirth,
                EmailId = user.EmailId,
                FirstName = user.FirstName,
                Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), lookupBusiness.GetLookupValue(user.GenderId)),
                LastName = user.LastName,
                ModifiedByUserId = user.ModifiedByUserId,
                ModifiedDate = user.ModifiedDate,
                Password = user.Password,
                UserId = user.UserId
            };
            return View(userModel);
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
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            User user = new User
            {
                CreatedByUserId = 1,// (int)Session["UserId"];
                ModifiedByUserId = 2,// (int)Session["UserId"];
                Address = formCollection["Address"],
                EmailId = formCollection["EmailId"],
                FirstName = formCollection["FirstName"],
                LastName = formCollection["LastName"],
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DateOfBirth = DateTime.Now,
                GenderId = lookupBusiness.GetLookupId("Gender", formCollection["Gender"]),
                Password = formCollection["Password"]
            };
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
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            User user = userBusiness.Get(id);
            UserModel userModel = new UserModel
            {
                Address = user.Address,
                CreatedByUserId = user.CreatedByUserId,
                CreatedDate = user.CreatedDate,
                DateOfBirth = user.DateOfBirth,
                EmailId = user.EmailId,
                FirstName = user.FirstName,
                Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), lookupBusiness.GetLookupValue(user.GenderId)),
                LastName = user.LastName,
                ModifiedByUserId = user.ModifiedByUserId,
                ModifiedDate = user.ModifiedDate,
                Password = user.Password,
                UserId = user.UserId
            };
            return View(userModel);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            //try
            //{
                // TODO: Add update logic here
                UserBusiness userBusiness = new UserBusiness(new UserDataAccess());
                LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
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
                user.GenderId = lookupBusiness.GetLookupId("Gender", formCollection["Gender"]);
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
            LookupBusiness lookupBusiness = new LookupBusiness(new LookupDataAccess());
            User user = userBusiness.Get(id);
            UserModel userModel = new UserModel();
            userModel.Address = user.Address;
            userModel.CreatedByUserId = user.CreatedByUserId;
            userModel.CreatedDate = user.CreatedDate;
            userModel.DateOfBirth = user.DateOfBirth;
            userModel.EmailId = user.EmailId;
            userModel.FirstName = user.FirstName;
            userModel.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), lookupBusiness.GetLookupValue(user.GenderId));
            userModel.LastName = user.LastName;
            userModel.ModifiedByUserId = user.ModifiedByUserId;
            userModel.ModifiedDate = user.ModifiedDate;
            userModel.Password = user.Password;
            userModel.UserId = user.UserId;
            return View(userModel);
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
