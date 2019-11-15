using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservations.Model_Layer;
using System.Data.SqlClient;

namespace AirlineReservations.DatabaseLayer
{
    class FlightDB : FlightDBIF
    {
        SqlConnectionStringBuilder conStringBuilder;
        SqlConnection con;

        public FlightDB()
        {
            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        private Flight objectBuilder(SqlDataReader dataReader)
        {
            Flight flight = null;
            if (dataReader.Read())
            {
                flight = new Flight(dataReader.GetString(0), dataReader.GetString(5), dataReader.GetString(1), 
                    dataReader.GetString(2), dataReader.GetString(4), dataReader.GetString(3));
            }
            return flight;
        }

        public int DeleteFlight(string flightNo)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string deleteFlight = "DELETE * FROM Flight WHERE flightId = @flightId";
            using(SqlCommand command = new SqlCommand(deleteFlight, con))
            {
                command.Parameters.AddWithValue("@flightId", flightNo);
                int result = command.ExecuteNonQuery();
                if(result == 0)
                {
                    con.Dispose();
                    return (int)SqlResult.Failure;
                }
                con.Dispose();
                return (int)SqlResult.Success;
            }
        }

        public ArrayList GetAllFlights()
        {
            ArrayList flights = new ArrayList();
            string getAllFlights = "SELECT * FROM Flights";
            con.Open();

            using(SqlCommand command = new SqlCommand(getAllFlights, con))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    flights.Add(objectBuilder(dataReader));
                }
                return flights;
            }
        }

        public Flight GetFlightById(string flightNo)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getFlight = "SELECT * FROM Flight WHERE flightId = @flightId";
            using (SqlCommand command = new SqlCommand(getFlight, con))
            {
                command.Parameters.AddWithValue("@flightId", flightNo);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    con.Dispose();
                    return objectBuilder(dataReader);
                }
                con.Dispose();
                return null;
                    
            }
        }

        public int InsertFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public int UpdateFlight(string flightNo, Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
