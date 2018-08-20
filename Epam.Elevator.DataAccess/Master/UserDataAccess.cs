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
            int genderLookupId = lookupDataAccess.GetLookupId("Gender", user.Gender.ToString());

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO MasterUsers(FirstName,LastName,Password,DateOfBirth,Gender,EmailId,Address,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate)values(@firstName,@lastName,@password,@dateOfBirth,@gender,@emailId,@address,@createdByUserId,@createDate,@modifiedByUserId,@modifiedDate)", sqlConnection);
                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@gender", genderLookupId);
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
                int genderLookupId = lookupDataAccess.GetLookupId("Gender", user.Gender.ToString());
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE MasterUsers SET FirstName = @firstName, LastName = @lastName," +
                                    "Password=@password,DateOfBirth = @dateOfBirth,EmailId=@emailId,Gender=@gender,Address=@address where UserId=@userId", sqlConnection);
                    command.Parameters.AddWithValue("@firstName", user.FirstName);
                    command.Parameters.AddWithValue("@userId", user.UserId);
                    command.Parameters.AddWithValue("@lastName", user.LastName);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@gender", genderLookupId);
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
            User user = new User();
            //try
            //{
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT UserId,FirstName,EmailId,LastName,Password,DateOfBirth,Gender,Address,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterUsers WHERE UserId = @userId", sqlConnection);
                    command.Parameters.AddWithValue("@userId", userId);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        user.UserId = (int)sqlDataReader["UserId"];
                        user.FirstName = (String)sqlDataReader["FirstName"];
                        user.LastName = (String)sqlDataReader["LastName"];
                        //   user.Gender = (String)sqlDataReader["Gender"]; have to think 
                        String lookupString = lookupDataAccess.GetLookupValue((int)sqlDataReader["Gender"]);
                    lookupString = "Female";
                        user.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), lookupString);
                        user.DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                        user.EmailId = (String)sqlDataReader["EmailId"];
                        user.Password = (String)sqlDataReader["Password"];
                        user.ModifiedByUserId = (int)sqlDataReader["ModifiedByUserId"];
                        user.ModifiedDate = (DateTime)sqlDataReader["ModifiedDate"];
                        user.CreatedByUserId = (int)sqlDataReader["CreatedByUserId"];
                        user.CreatedDate = (DateTime)sqlDataReader["CreateDate"];
                        user.Address = (String)sqlDataReader["Address"];
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
                    SqlCommand command = new SqlCommand("SELECT UserId,FirstName,LastName,Password,DateOfBirth,Gender,EmailId,Address,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterUsers", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        User user = new User();
                        user.UserId = (int)sqlDataReader["UserId"];
                        user.FirstName = (String)sqlDataReader["FirstName"];
                        user.LastName = (String)sqlDataReader["LastName"];
                        String lookupString = lookupDataAccess.GetLookupValue((int)sqlDataReader["Gender"]);
                    lookupString = "Female";
                        user.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), lookupString);
                        user.DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                        user.EmailId = (String)sqlDataReader["EmailId"];
                        user.ModifiedByUserId = (int)sqlDataReader["ModifiedByUserId"];
                        user.ModifiedDate = (DateTime)sqlDataReader["ModifiedDate"];
                        user.CreatedByUserId = (int)sqlDataReader["CreatedByUserId"];
                        user.CreatedDate = (DateTime)sqlDataReader["CreateDate"];
                        user.Address = (String)sqlDataReader["Address"];
                        user.Password = (String)sqlDataReader["Password"];
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
                    SqlCommand command = new SqlCommand("SELECT FirstName,LastName,Password,DateOfBirth,Gender,EmailId,Address,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterUsers WHERE FirstName=@searchString or LastName=@searchString or Gender=@searchString or EmailId=@searchString or Address=@searchString", sqlConnection);
                    command.Parameters.AddWithValue("@searchString", "%"+searchString+"%");
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        User user = new User();
                        user.UserId = (int)sqlDataReader["UserId"];
                        user.FirstName = (String)sqlDataReader["FirstName"];
                        user.LastName = (String)sqlDataReader["LastName"];
                        String lookupString = lookupDataAccess.GetLookupValue((int)sqlDataReader["Gender"]);
                        user.Gender = (Enums.Gender)Enum.Parse(typeof(Enums.Gender), lookupString);
                        user.DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                        user.EmailId = (String)sqlDataReader["EmailId"];
                        user.ModifiedByUserId = (int)sqlDataReader["ModifiedByUserId"];
                        user.ModifiedDate = (DateTime)sqlDataReader["ModifiedDate"];
                        user.CreatedByUserId = (int)sqlDataReader["CreatedByUserId"];
                        user.CreatedDate = (DateTime)sqlDataReader["CreateDate"];
                        user.Address = (String)sqlDataReader["Address"];
                        user.Password = (String)sqlDataReader["Password"];
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
