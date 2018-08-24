using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Epam.Elevator.Models.Master;
using Epam.Elevator.DataAccess.Master.Interfaces;
using System;
using Epam.Elevator.Models;
using System.Collections.Generic;
using System.Configuration;

namespace Epam.Elevator.DataAccess.Master
{
    public class UserDataAccess : IUserDataAccess
    {

        private readonly String connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public bool Create(User user)
        {
            bool result = false;
            //try
            // {
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
            // }
            // catch(Exception e)
            // {
            //e.printStackTrace();
            //     e.StackTrace;
            // }
            return result;

        }
        public bool Update(User user)
        {
            bool result = false;
            //try
            //{
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

            //}
            //catch
            //{

            //}
            return result;
        }
        public bool Delete(int userId)
        {

            bool result = false;
            try
            {
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
            }
            catch
            {
            }
            return result;
        }
        public User Get(int userId)
        {
            User user = null;
            //try
            //{
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetUSer", sqlConnection)
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
                foreach (DataRow row in dataSet.Tables["Users"].Rows)
                {
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
            //}
            //catch
            //{
            //}
            return user;
        }
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            //try
            //{
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
            //}
            //catch
            //{
            //}
            return userList;
        }
        public List<User> SearchUsers(String searchString)
        {
            List<User> userList = new List<User>();
            try
            {
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
            }
            catch
            {
            }
            return userList;
        }
    }
}
