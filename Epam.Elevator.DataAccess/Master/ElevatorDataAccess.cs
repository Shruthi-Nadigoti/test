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
        #region Properties
        private readonly String connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        #endregion
        #region Methods
        /// <summary>
        /// Takes the Elevator object and insert into database
        /// </summary>
        /// <param name="elevator"></param>
        /// <returns></returns>
        public bool Create(ElevatorModel.Elevator elevator)
        {
            bool result = false;
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
                command.Parameters.AddWithValue("@createdByUserId", elevator.CreatedByUserId);
                command.Parameters.AddWithValue("@createdDate", elevator.CreatedDate);
                command.Parameters.AddWithValue("@modifiedUserId", elevator.ModifiedByUserId);
                command.Parameters.AddWithValue("@modifiedDate", elevator.ModifiedDate);
                sqlConnection.Open();
                result = command.ExecuteNonQuery() > 0 ? true : false;

            }
            return result;

        }
        /// <summary>
        /// Takes the Elevator object and update it into database
        /// </summary>
        /// <param name="elevator"></param>
        /// <returns></returns>
        public bool Update(ElevatorModel.Elevator elevator)
        {
            bool result = false;

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

            return result;
        }
        /// <summary>
        /// Delete the elevator based on elevatorid that has been passed
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns></returns>
        public bool Delete(int elevatorId)
        {

            bool result = false;
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
            return result;
        }
        /// <summary>
        /// Returns elevator list 
        /// </summary>
        /// <returns></returns>
        public List<ElevatorModel.Elevator> GetElevators()
        {
            List<ElevatorModel.Elevator> elevatorList = new List<ElevatorModel.Elevator>();

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
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                    };

                    elevatorList.Add(elevator);
                }
            }
            return elevatorList;
        }
        /// <summary>
        /// Returns corresponding elevator object based on elevatorid 
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns></returns>
        public ElevatorModel.Elevator GetElevator(int elevatorId)
        {
            ElevatorModel.Elevator elevator = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetElevator", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@elevatorId", elevatorId);
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Elevators");
                if(dataSet.Tables["Elevators"].Rows.Count>0)
                {
                    DataRow row = dataSet.Tables["Elevators"].Rows[0];
                    elevator = new ElevatorModel.Elevator
                    {
                        ElevatorId = Convert.ToInt32(row["ElevatorId"]),
                        ElevatorName = Convert.ToString(row["ElevatorName"]),
                        FloorDuration = Convert.ToInt32(row["FloorDuration"]),
                        MainStatusId = Convert.ToInt32(row["MainStatusId"]),
                        MaxWeight = Convert.ToInt32(row["MaxWeight"]),
                        ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                    };
                }
            }
            return elevator;
        }
        /// <summary>
        /// Return elevator list that matches with string that passed
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<ElevatorModel.Elevator> SearchElevators(String searchString)
        {
            List<ElevatorModel.Elevator> elevatorList = new List<ElevatorModel.Elevator>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SearchElevators", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");
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
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                    };
                    elevatorList.Add(elevator);
                }
            }
            return elevatorList;
        }
        #endregion

    }
}
