using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Elevator.Models.Master;
using System.Configuration;
using System.Data.SqlClient;
using Epam.Elevator.DataAccess.Master.Interfaces;

namespace Epam.Elevator.DataAccess.Master
{
    public class LookupDataAccess: ILookupDataAccess
    {
        private readonly String connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public  bool UpdateLookup()
        {
            return true;
        }
        public  bool DeleteLookup()
        {
            return true;
        }
        public int GetLookupId(String key,String value)
        {
            int id = -1;
            try
            {
                
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("select id from MasterLookup where Key=@key and Value=@value");
                    command.Parameters.AddWithValue("@key", key);
                    command.Parameters.AddWithValue("@value", value);
                    sqlConnection.Open();
                    id = (int)command.ExecuteScalar();
                }
            }
            catch
            {
            }
            return id;
            
        }
        public String GetLookupValue(int id)
        {
            String result = String.Empty; 
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("select id from MasterLookup where Key=@key and LookupId=@id");
                    command.Parameters.AddWithValue("@id", id);
                    sqlConnection.Open();
                    result= (String)command.ExecuteScalar();
                }
             
            }
            catch
            {
               
            }
            return result;

        }
        public  bool SaveLookup()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("select id from MasterLookup where key=");

            }
            catch
            {

            }
            return true;
        }
    }
}
