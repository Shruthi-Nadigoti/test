using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Epam.Elevator.DataAccess.Master.Interfaces;
using Epam.Elevator.Models.Master;
namespace Epam.Elevator.DataAccess.Master
{
    public class FloorDataAccess : IFloorDataAccess
    {
        #region Properties
        private readonly String connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        #endregion
        #region Methods
        /// <summary>
        /// Creates given Floor Object in Database
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        public bool Create(Floor floor)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CreateFloor", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@floorName", floor.FloorName);
                command.Parameters.AddWithValue("@createdByUserId", floor.CreatedByUserId);
                command.Parameters.AddWithValue("@createdDate", floor.CreatedDate);
                command.Parameters.AddWithValue("@modifiedUserId", floor.ModifiedByUserId);
                command.Parameters.AddWithValue("@modifiedDate", floor.ModifiedDate);
                sqlConnection.Open();
                result = command.ExecuteNonQuery() > 0 ? true : false;
            }
            return result;

        }
        /// <summary>
        /// Update gives Floor Object in Database
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        public bool Update(Floor floor)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateFloor", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@floorId", floor.FloorId);
                sqlConnection.Open();
                result = command.ExecuteNonQuery() > 0 ? true : false;
            }
            return result;
        }
        /// <summary>
        /// Delete floor object based on floor id that passed
        /// </summary>
        /// <param name="floorId"></param>
        /// <returns></returns>
        public bool Delete(int floorId)
        {

            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteFloor", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@floorId", floorId);
                sqlConnection.Open();
                result = command.ExecuteNonQuery() > 0 ? true : false;

            }
            return result;
        }
        /// <summary>
        /// Returns the floor list
        /// </summary>
        /// <returns></returns>
        public List<Floor> GetFloors()
        {
            List<Floor> floorList = new List<Floor>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetFloors", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Floors");
                foreach (DataRow row in dataSet.Tables["Floors"].Rows)
                {
                    Floor floor = new Floor
                    {
                        FloorId = Convert.ToInt32(row["FloorId"]),
                        FloorName = Convert.ToString(row["FloorName"]),
                        ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                    };
                    floorList.Add(floor);
                }
            }
            return floorList;
        }
        /// <summary>
        /// Returns the list of floor that matches with the string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<Floor> SearchFloors(String searchString)
        {
            List<Floor> floorList = new List<Floor>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SearchFloors", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Floors");
                foreach (DataRow row in dataSet.Tables["Floors"].Rows)
                {
                    Floor floor = new Floor
                    {
                        FloorId = Convert.ToInt32(row["FloorId"]),
                        FloorName = Convert.ToString(row["FloorName"]),
                        ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                    };
                    floorList.Add(floor);
                }
            }
            return floorList;
        }
        /// <summary>
        /// Returns the floor object based on floor id
        /// </summary>
        /// <param name="floorId"></param>
        /// <returns></returns>
        public Floor Get(int floorId)
        {
            Floor floor = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetFloor", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@floorId", floorId);
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Floors");
                if (dataSet.Tables["Floors"].Rows.Count > 0)
                {
                    DataRow row = dataSet.Tables["Floors"].Rows[0];
                    floor = new Floor
                    {
                        FloorId = Convert.ToInt32(row["FloorId"]),
                        FloorName = Convert.ToString(row["FloorName"]),
                        ModifiedByUserId = Convert.ToInt32(row["ModifiedByUserId"]),
                        ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
                        CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                    };

                }
            }
            return floor;
        }
        #endregion
    }
}
