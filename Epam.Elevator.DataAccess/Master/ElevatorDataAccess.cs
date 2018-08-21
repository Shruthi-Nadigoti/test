using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Epam.Elevator.DataAccess.Master.Interfaces;
using ElevatorModel = Epam.Elevator.Models.Master;

namespace Epam.Elevator.DataAccess.Master
{
    public class ElevatorDataAccess : IElevatorDataAccess
    {
        private readonly String connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public bool Create(ElevatorModel.Elevator elevator)
        {
            bool result = false;
            //try
            // {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO MasterElevator(ElevatorName,MaxWeight,FloorDuration,MainStatusId,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate)values(@elevatorName,@maxWeight,@floorDuration,@mainStatusId,@createdByUserId,@createDate,@modifiedByUserId,@modifiedDate)", sqlConnection);
                command.Parameters.AddWithValue("@elevatorName", elevator.ElevatorName);
                command.Parameters.AddWithValue("@floorDuration", elevator.FloorDuration);
                command.Parameters.AddWithValue("@maxWeight", elevator.MaxWeight);
                command.Parameters.AddWithValue("@mainStatusId", elevator.MainStatusId);
                command.Parameters.AddWithValue("@createByUserId",elevator.CreatedByUserId);
                command.Parameters.AddWithValue("@createDate", elevator.CreatedDate);
                command.Parameters.AddWithValue("@modifiedUserId", elevator.ModifiedByUserId);
                command.Parameters.AddWithValue("@modifiedDate", elevator.ModifiedDate);
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
        public bool Update(ElevatorModel.Elevator elevator)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE MasterElevator SET ElevatorName = @elevatorName, FloorDuration=@floorDuration, MaxWeight=@maxWeight, MainStatusId= @mainStatusId where ElevatorId=@elevatorId)", sqlConnection);
                    command.Parameters.AddWithValue("@elevatorName", elevator.ElevatorName);
                    command.Parameters.AddWithValue("@floorDuration", elevator.FloorDuration);
                    command.Parameters.AddWithValue("@maxWeight", elevator.MaxWeight);
                    command.Parameters.AddWithValue("@mainStatusId", elevator.MainStatusId);
                    sqlConnection.Open();
                    result = command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
            catch
            {

            }
            return result;
        }
        public bool Delete(int elevatorId)
        {

            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM MasterElevators WHERE ElevatorId = @elevatorId", sqlConnection);
                    command.Parameters.AddWithValue("@elevatorId", elevatorId);
                    sqlConnection.Open();
                    result = command.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch
            {
            }
            return result;
        }
        public List<ElevatorModel.Elevator> GetElevators()
        {
            List<ElevatorModel.Elevator> elevatorList = new List<ElevatorModel.Elevator>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT ElevatorId, ElevatorName,MaxWeight,FloorDuration,MainStatusId,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterElevators", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ElevatorModel.Elevator elevator = new ElevatorModel.Elevator
                        {
                            ElevatorId = Convert.ToInt32(sqlDataReader["ElevatorId"]),
                            ElevatorName = Convert.ToString(sqlDataReader["ElevatorName"]),
                            FloorDuration = (TimeSpan)sqlDataReader["FloorDuration"],
                            MainStatusId = Convert.ToInt32(sqlDataReader["MainStatusId"]),
                            MaxWeight = Convert.ToInt32(sqlDataReader["MaxWeight"]),
                            ModifiedByUserId = Convert.ToInt32(sqlDataReader["ModifiedByUserId"]),
                            ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]),
                            CreatedByUserId = Convert.ToInt32(sqlDataReader["CreateByUserId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreateDate"])
                        };
                        elevatorList.Add(elevator);
                    }
                }
            }
            catch
            {
            }
            return elevatorList;
        }
        public List<ElevatorModel.Elevator> SearchElevators(String searchString)
        {
            List<ElevatorModel.Elevator> elevatorList = new List<ElevatorModel.Elevator>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT ElevatorId, ElevatorName,MaxWeight,FloorDuration,MainStatusId,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterElevators WHERE FloorName=@searchString or FloorDuration=@searchString or MaxWeight=@searchString or MainStatusId=@searchString ", sqlConnection);
                    command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ElevatorModel.Elevator elevator = new ElevatorModel.Elevator
                        {
                            ElevatorId = Convert.ToInt32(sqlDataReader["ElevatorId"]),
                            ElevatorName = Convert.ToString(sqlDataReader["ElevatorName"]),
                            FloorDuration = (TimeSpan)sqlDataReader["FloorDuration"],
                            MainStatusId = Convert.ToInt32(sqlDataReader["MainStatusId"]),
                            MaxWeight = Convert.ToInt32(sqlDataReader["MaxWeight"]),
                            ModifiedByUserId = Convert.ToInt32(sqlDataReader["ModifiedByUserId"]),
                            ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]),
                            CreatedByUserId = Convert.ToInt32(sqlDataReader["CreateByUserId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreateDate"])
                        };
                        elevatorList.Add(elevator);
                    }
                }
            }
            catch
            {
            }
            return elevatorList;
        }

       
    }
}
