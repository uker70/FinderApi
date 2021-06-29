using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinderApi.Database
{
    public class StoredProcedureCalls
    {
        //connection string
        private static string connectionString = "Server=localhost;Database=FinderGIS;Trusted_Connection=True;";

        public static string PostUser(double latitude, double longitude)
        {
            string result = "";

            // Establish connection to database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Latitude", SqlDbType.Decimal).Value = latitude;
                cmd.Parameters.Add("@Longitude", SqlDbType.Decimal).Value = longitude;

                //Read data from database
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = $"{reader["id"]}";
                    }
                }
            }

            return result;
        }

        public static bool DeleteUser(int id)
        {
            bool result = false;
            // Establish connection to database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
                result = true;
            }

            return result;
        }

        public static string GetUser(int id)
        {
            string result = "";

            // Establish connection to database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                // Read data from database
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string row = $"\"{reader["lat"]}\", \"{reader["long"]}\"\n";

                        result += row;
                    }
                }
            }

            return result;
        }

        public static string GetDistanceFromUser(int id, int distance)
        {
            string result = "";

            // Establish connection to database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetWithinDistance", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Distance", SqlDbType.Int).Value = distance;

                // Read data from database
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string row = $"\"{reader["id"]}\", \"{reader["latitude"]}\", \"{reader["longitude"]}\"\n";

                        result += row;
                    }
                }
            }

            return result;
        }
    }
}