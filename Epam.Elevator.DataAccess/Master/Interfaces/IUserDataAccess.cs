using Epam.Elevator.Models.Master;
using System;
using System.Collections.Generic;

namespace Epam.Elevator.DataAccess.Master.Interfaces
{
    public interface IUserDataAccess
    {
        /// <summary>
        /// Takes the User object and insert into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Create(User user);
        /// <summary>
        /// Takes the User object and update it into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Update(User user);
        /// <summary>
        /// delete the corresponding user based on user Id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns></returns>
        bool Delete(int userId);
        /// <summary>
        /// Gives the One user based on user id that passed as parameter
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User Get(int userId);
        /// <summary>
        /// Gives the User list 
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();
        /// <summary>
        /// Takes the string and gives the list of user that matches with any one the attribute
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        List<User> SearchUsers(String searchString);
        User IsValidUser(String emailId, String password);

    }
}
