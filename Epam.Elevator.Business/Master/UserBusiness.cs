using Epam.Elevator.DataAccess.Master;
using Epam.Elevator.Models.Master;
using Epam.Elevator.DataAccess.Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.Business.Master
{
    public class UserBusiness
    {
        IUserDataAccess userDataAccess;
       
        public UserBusiness(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }
        public  bool Update(User user)
        {

            bool result = userDataAccess.Update(user);
            return result;
        }
        public User Get(int userId)
        {

            User user = userDataAccess.Get(userId);
            return user;
        }
        public bool Delete(int userId)
        {

            bool result = userDataAccess.Delete(userId);
            return result;
        }
        public List<User> GetUsers()
        {
            List<User> userList = userDataAccess.GetUsers();
            return userList;
        }
        public  bool Create(User user)
        {

            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.DateOfBirth = DateTime.Now;
            bool result = userDataAccess.Create(user);
            return result;
        }
    }
}
