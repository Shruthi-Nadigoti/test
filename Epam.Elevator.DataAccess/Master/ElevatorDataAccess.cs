using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                SqlCommand command = new SqlCommand("CreateElevator", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@elevatorName", elevator.ElevatorName);
                command.Parameters.AddWithValue("@floorDuration", elevator.FloorDuration);
                command.Parameters.AddWithValue("@maxWeight", elevator.MaxWeight);
                command.Parameters.AddWithValue("@mainStatusId", elevator.MainStatusId);
                command.Parameters.AddWithValue("@createByUserId", elevator.CreatedByUserId);
                command.Parameters.AddWithValue("@createDate", elevator.CreatedDate);
                command.Parameters.AddWithValue("@modifiedUserId", elevator.ModifiedByUserId);
                command.Parameters.AddWithValue("@modifiedDate", elevator.ModifiedDate);
                sqlConnection.Open();
                result = command.ExecuteNonQuery() > 0 ? true : false;

            }
            // }
            // catch(Exception e)
            // {
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
                    SqlCommand command = new SqlCommand("UpdateElevator", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
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
                    SqlCommand command = new SqlCommand("DeleteElevator", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

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
            //try
            //{
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetElevators", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Elevators");
                foreach (DataRow row in dataSet.Tables["Elevators"].Rows)
                {
                    ElevatorModel.Elevator elevator = new ElevatorModel.Elevator
                    {
                        ElevatorId = Convert.ToInt32(row["ElevatorId"]),
                        ElevatorName = Convert.ToString(row["ElevatorName"]),
                        FloorDuration = Convert.ToInt32(row["FloorDuration"]),
                        MainStatusId = Convert.ToInt32(row["MainStatusId"]),
                        MaxWeight = Convert.ToInt32(row["MaxWeight"]),
                        ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(row["CreateDate"])
                    };

                    elevatorList.Add(elevator);
                }
            }
            //}
            //catch
            //{
            //}
            return elevatorList;
        }
        public List<ElevatorModel.Elevator> SearchElevators(String searchString)
        {
            List<ElevatorModel.Elevator> elevatorList = new List<ElevatorModel.Elevator>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SearchElevators", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Elevators");
                    foreach (DataRow row in dataSet.Tables["Elevators"].Rows)
                    {
                        ElevatorModel.Elevator elevator = new ElevatorModel.Elevator
                        {
                            ElevatorId = Convert.ToInt32(row["ElevatorId"]),
                            ElevatorName = Convert.ToString(row["ElevatorName"]),
                            FloorDuration = Convert.ToInt32(row["FloorDuration"]),
                            MainStatusId = Convert.ToInt32(row["MainStatusId"]),
                            MaxWeight = Convert.ToInt32(row["MaxWeight"]),
                            ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                            ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                            CreatedByUserId = Convert.ToInt32(row["CreateByUserId"]),
                            CreatedDate = Convert.ToDateTime(row["CreateDate"])
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
