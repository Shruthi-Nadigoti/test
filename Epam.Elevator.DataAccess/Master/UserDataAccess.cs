using System.Data.SqlClient;
using System.Data;
using Epam.Elevator.Models.Master;
using Epam.Elevator.DataAccess.Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Epam.Elevator.DataAccess.Master
{
    public class UserDataAccess : IUserDataAccess
    {
        #region Properties
        private readonly String connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        #endregion
        #region Methods
        /// <summary>
        /// Takes the User object and insert into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Create(User user)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CreateUser", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@genderId", user.GenderId);
                command.Parameters.AddWithValue("@address", user.Address);
                command.Parameters.AddWithValue("@createdByUserId", user.CreatedByUserId);
                command.Parameters.AddWithValue("@createDate", user.CreatedDate);
                command.Parameters.AddWithValue("@modifiedByUserId", user.ModifiedByUserId);
                command.Parameters.AddWithValue("@modifiedDate", user.ModifiedDate);
                command.Parameters.AddWithValue("@emailId", user.EmailId);
                sqlConnection.Open();
                result = command.ExecuteNonQuery() > 0 ? true : false;

            }
            return result;

        }
        public User IsValidUser(String emailId,String password)
        {
            User user = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("isValidUser", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@emailId", emailId);
                command.Parameters.AddWithValue("@password", password);
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Users");
                if (dataSet.Tables["Users"].Rows.Count > 0)
                {
                    DataRow row = dataSet.Tables["Users"].Rows[0];
                    user = new User
                    {
                        UserId = Convert.ToInt32(row["UserId"]),
                        FirstName = Convert.ToString(row["FirstName"]),
                        LastName = Convert.ToString(row["LastName"]),
                        GenderId = Convert.ToInt32(row["GenderId"]),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        EmailId = Convert.ToString(row["EmailId"]),
                        ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(row["CreateDate"]),
                        Address = Convert.ToString(row["Address"]),
                        Password = Convert.ToString(row["Password"])
                    };
                }
            }
            return user;

        }
        /// <summary>
        /// Takes the User object and update it into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateUser", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@userId", user.UserId);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@GenderId", user.GenderId);
                command.Parameters.AddWithValue("@address", user.Address);
                command.Parameters.AddWithValue("@emailId", user.EmailId);
                sqlConnection.Open();
                result = command.ExecuteNonQuery() > 0 ? true : false;
            }
            return result;
        }
        /// <summary>
        /// delete the corresponding user based on user Id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns></returns>
        public bool Delete(int userId)
        {

            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteUser", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@userId", userId);
                sqlConnection.Open();
                result = command.ExecuteNonQuery() > 0 ? true : false;
            }
            return result;
        }
        /// <summary>
        /// Gives the One user based on user id that passed as parameter
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User Get(int userId)
        {
            User user = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetUser", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@userId", userId);
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Users");
                if (dataSet.Tables["Users"].Rows.Count > 0)
                {
                    DataRow row = dataSet.Tables["Users"].Rows[0];
                    user = new User
                    {
                        UserId = Convert.ToInt32(row["UserId"]),
                        FirstName = Convert.ToString(row["FirstName"]),
                        LastName = Convert.ToString(row["LastName"]),
                        GenderId = Convert.ToInt32(row["GenderId"]),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        EmailId = Convert.ToString(row["EmailId"]),
                        ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(row["CreateDate"]),
                        Address = Convert.ToString(row["Address"]),
                        Password = Convert.ToString(row["Password"])
                    };
                }
            }
            return user;
        }
        /// <summary>
        /// Gives the User list 
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetUsers", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Users");
                foreach (DataRow row in dataSet.Tables["Users"].Rows)
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(row["UserId"]),
                        FirstName = Convert.ToString(row["FirstName"]),
                        LastName = Convert.ToString(row["LastName"]),
                        GenderId = Convert.ToInt32(row["GenderId"]),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        EmailId = Convert.ToString(row["EmailId"]),
                        ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(row["CreateDate"]),
                        Address = Convert.ToString(row["Address"]),
                        Password = Convert.ToString(row["Password"])
                    };
                    userList.Add(user);
                }
            }
            return userList;
        }
        /// <summary>
        /// Takes the string and gives the list of user that matches with any one the attribute
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<User> SearchUsers(String searchString)
        {
            List<User> userList = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SearchUsers", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Users");
                foreach (DataRow row in dataSet.Tables["Users"].Rows)
                {
                    User user = new User
                    {
                        UserId = (int)row["UserId"],
                        FirstName = (String)row["FirstName"],
                        LastName = (String)row["LastName"],
                        GenderId = (int)row["GenderId"],
                        DateOfBirth = (DateTime)row["DateOfBirth"],
                        EmailId = (String)row["EmailId"],
                        ModifiedByUserId = (int)row["ModifiedByUserId"],
                        ModifiedDate = (DateTime)row["ModifiedDate"],
                        CreatedByUserId = (int)row["CreatedByUserId"],
                        CreatedDate = (DateTime)row["CreateDate"],
                        Address = (String)row["Address"],
                        Password = (String)row["Password"],
                    };
                    userList.Add(user);
                }
            }
            return userList;
        }
        #endregion 
    }
}




