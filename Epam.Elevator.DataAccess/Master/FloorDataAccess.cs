using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Elevator.DataAccess.Master.Interfaces;
using Epam.Elevator.Models;
using Epam.Elevator.Models.Master;
namespace Epam.Elevator.DataAccess.Master
{
    public class FloorDataAccess:IFloorDataAccess
    {
        private readonly String connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public bool Create(Floor floor)
        {
            bool result = false;
            //try
            // {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO MasterFloors(FloorName,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate)values(@floorName,@createdByUserId,@createDate,@modifiedByUserId,@modifiedDate)", sqlConnection);
                command.Parameters.AddWithValue("@floorName", floor.FloorName);
                command.Parameters.AddWithValue("@createByUserId", floor.CreatedByUserId);
                command.Parameters.AddWithValue("@createDate", floor.CreatedDate);
                command.Parameters.AddWithValue("@modifiedUserId", floor.ModifiedByUserId);
                command.Parameters.AddWithValue("@modifiedDate", floor.ModifiedDate);
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
        public bool Update(int floorId)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE MasterFloors SET FloorName = @firstName where FloorId=@floorId)", sqlConnection);
                    command.Parameters.AddWithValue("@floorId", floorId);
                    sqlConnection.Open();
                    result = command.ExecuteNonQuery() > 0 ? true : false;
                }

            }
            catch
            {

            }
            return result;
        }
        public bool Delete(int floorId)
        {

            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM MasterFloors WHERE FloorId = @floorId", sqlConnection);
                    command.Parameters.AddWithValue("@floorId", floorId);
                    sqlConnection.Open();
                    result = command.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch
            {
            }
            return result;
        }
        public List<Floor> GetFloors()
        {
            List<Floor> floorList = new List<Floor>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT FloorId,FloorName,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterFloors", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Floor floor = new Floor
                        {
                            FloorId = Convert.ToInt32(sqlDataReader["FloorId"]),
                            FloorName = Convert.ToString(sqlDataReader["FloorName"]),
                            ModifiedByUserId = Convert.ToInt32(sqlDataReader["ModifiedByUserId"]),
                            ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]),
                            CreatedByUserId = Convert.ToInt32(sqlDataReader["CreateByUserId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreateDate"])
                        };
                        floorList.Add(floor);
                    }
                }
            }
            catch
            {
            }
            return floorList;
        }
        public List<Floor> SearchFloors(String searchString)
        {
            List<Floor> floorList = new List<Floor>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT FloorId,FloorName,CreatedByUserId,CreateDate,ModifiedByUserId,ModifiedDate FROM MasterFloors WHERE FloorName=@searchString ", sqlConnection);
                    command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Floor floor = new Floor
                        {
                            FloorId = Convert.ToInt32(sqlDataReader["FloorId"]),
                            FloorName = Convert.ToString(sqlDataReader["FloorName"]),
                            ModifiedByUserId = Convert.ToInt32(sqlDataReader["ModifiedByUserId"]),
                            ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]),
                            CreatedByUserId = Convert.ToInt32(sqlDataReader["CreateByUserId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreateDate"])
                        };
                        floorList.Add(floor);
                    }
                }
            }
            catch
            {
            }
            return floorList;
        }

       

    }
}
