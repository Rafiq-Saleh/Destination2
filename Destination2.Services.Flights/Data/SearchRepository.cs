using Destination2.Services.Flights.Entities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Destination2.Services.Flights.Data
{
    internal interface ISearchRepository
    {
        int SearchFlightStart(FlightSearch flightSearch);
    }

    internal class SearchRepository : ISearchRepository
    {
        private readonly string connectionString;

        public SearchRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int SearchFlightStart(FlightSearch flightSearch)
        {
            int newRow;
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SearchFlightStart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SearchType", SqlDbType.VarChar, 50).Value = DateTime.Now;
                    cmd.Parameters.Add("@IsPackage", SqlDbType.Bit).Value = flightSearch.IsPackage;     

                    cmd.Parameters.Add("@SearchFlightId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    newRow = (int)cmd.Parameters["@SearchFlightId"].Value;


                }
            }
            return newRow;
        }
    }
}