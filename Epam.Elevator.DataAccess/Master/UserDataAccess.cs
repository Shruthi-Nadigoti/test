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
        LookupDataAccess lookupDataAccess = new LookupDataAccess();
        private readonly String connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public bool Create(User user)
        {
            bool result = false;
            //try
            // {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO MasterUsers(FirstName,LastName,Password,DateOfBirth,GenderId,EmailId,Address,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate)values(@firstName,@lastName,@password,@dateOfBirth,@GenderId,@emailId,@address,@createdByUserId,@createDate,@modifiedByUserId,@modifiedDate)", sqlConnection);
                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@GenderId", user.GenderId);
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
            int GenderIdLookupId = lookupDataAccess.GetLookupId("GenderId", user.GenderId.ToString());
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE MasterUsers SET FirstName = @firstName, LastName = @lastName," +
                                "Password=@password,DateOfBirth = @dateOfBirth,EmailId=@emailId,GenderId=@GenderId,Address=@address where UserId=@userId", sqlConnection);
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
                    SqlCommand command = new SqlCommand("DELETE FROM MasterUsers WHERE UserId = @userId", sqlConnection);
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
                SqlCommand command = new SqlCommand("SELECT UserId,FirstName,EmailId,LastName,Password,DateOfBirth,GenderId,Address,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterUsers WHERE UserId = @userId", sqlConnection);
                command.Parameters.AddWithValue("@userId", userId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    user = new User
                    {
                        UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                        FirstName = Convert.ToString(sqlDataReader["FirstName"]),
                        LastName = Convert.ToString(sqlDataReader["LastName"]),
                        GenderId = Convert.ToInt32(sqlDataReader["GenderId"]),
                        DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]),
                        EmailId = Convert.ToString(sqlDataReader["EmailId"]),
                        ModifiedByUserId = Convert.ToInt32(sqlDataReader["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(sqlDataReader["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(sqlDataReader["CreateDate"]),
                        Address = Convert.ToString(sqlDataReader["Address"]),
                        Password = Convert.ToString(sqlDataReader["Password"])
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
                SqlCommand command = new SqlCommand("SELECT UserId,FirstName,LastName,Password,DateOfBirth,GenderId,EmailId,Address,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterUsers", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                        FirstName = Convert.ToString(sqlDataReader["FirstName"]),
                        LastName = Convert.ToString(sqlDataReader["LastName"]),
                        GenderId = Convert.ToInt32(sqlDataReader["GenderId"]),
                        DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]),
                        EmailId = Convert.ToString(sqlDataReader["EmailId"]),
                        ModifiedByUserId = Convert.ToInt32(sqlDataReader["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(sqlDataReader["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(sqlDataReader["CreateDate"]),
                        Address = Convert.ToString(sqlDataReader["Address"]),
                        Password = Convert.ToString(sqlDataReader["Password"])
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
                    SqlCommand command = new SqlCommand("SELECT FirstName,LastName,Password,DateOfBirth,GenderId,EmailId,Address,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterUsers WHERE FirstName=@searchString or LastName=@searchString or GenderId=@searchString or EmailId=@searchString or Address=@searchString", sqlConnection);
                    command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        User user = new User
                        {
                            UserId = (int)sqlDataReader["UserId"],
                            FirstName = (String)sqlDataReader["FirstName"],
                            LastName = (String)sqlDataReader["LastName"],
                            GenderId = (int)sqlDataReader["GenderId"],
                            DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"],
                            EmailId = (String)sqlDataReader["EmailId"],
                            ModifiedByUserId = (int)sqlDataReader["ModifiedByUserId"],
                            ModifiedDate = (DateTime)sqlDataReader["ModifiedDate"],
                            CreatedByUserId = (int)sqlDataReader["CreatedByUserId"],
                            CreatedDate = (DateTime)sqlDataReader["CreateDate"],
                            Address = (String)sqlDataReader["Address"],
                            Password = (String)sqlDataReader["Password"],
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
