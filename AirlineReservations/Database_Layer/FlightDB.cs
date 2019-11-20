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
    public class FlightDB : FlightDBIF
    {
        SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();
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
            Flight flight = new Flight(dataReader.GetString(5), dataReader.GetDateTime(1), 
                    dataReader.GetDateTime(2), dataReader.GetString(4), dataReader.GetString(3));
            flight.FlightNo = "" + dataReader.GetInt32(0);
            return flight;
        }

        public SuccessState DeleteFlight(string flightNo)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string deleteFlight = "DELETE * FROM Flight WHERE flightId = @flightId";
            int result = 0;
            using(SqlCommand command = new SqlCommand(deleteFlight, con))
            {
                command.Parameters.AddWithValue("@flightId", flightNo);
                result = command.ExecuteNonQuery();
            }
            if (result == 0)
            {
                con.Dispose();
                return SuccessState.DBUnreachable;
            }
            con.Dispose();
            return SuccessState.Success;
        }

        public ArrayList GetAllFlights()
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            ArrayList flights = new ArrayList();
            string getAllFlights = "SELECT * FROM Flight";
            con.Open();

            using(SqlCommand command = new SqlCommand(getAllFlights, con))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    flights.Add(objectBuilder(dataReader));
                }
            }
            con.Dispose();
            return flights;
        }

        public Flight GetFlightById(string flightNo)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getFlight = "SELECT * FROM Flight WHERE flightId = @flightId";
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(getFlight, con))
            {
                command.Parameters.AddWithValue("@flightId", flightNo);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    flight = objectBuilder(dataReader);
                }
                    
            }
            return flight;
        }

        public SuccessState InsertFlight(Flight flight)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string insertFlight = "INSERT INTO Flight (departureTime, arrivalTime, departureLocation" +
                "destination, modelId) VALUES(@departureTime, @arrivalTime, @departureLocation, @destination, @modelId";
            int result = 0;
            using (SqlCommand command = new SqlCommand(insertFlight, con))
            {
                command.Parameters.AddWithValue("@departureTime", flight.DepartureTime);
                command.Parameters.AddWithValue("@arrivalTime", flight.ArrivalTime);
                command.Parameters.AddWithValue("@departureLocation", flight.DepartureLocation);
                command.Parameters.AddWithValue("@destination", flight.Destination);
                command.Parameters.AddWithValue("@modelId", flight.Model);
                result = command.ExecuteNonQuery();
            }
            if (result == 0)
            {
                con.Dispose();
                return SuccessState.DBUnreachable;
            }
            con.Dispose();
            return SuccessState.Success;
        }

        public SuccessState UpdateFlight(string flightNo, Flight flight)
        {
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string updateFlight = "UPDATE Flight SET departureTime = @departureTime, arrivalTime = @arrivalTime" +
                "departureLocation = @departureLocation, destination = @destination, modelId = @modelId WHERE flightId = @flightId";
            int result = 0;
            using (SqlCommand command =new SqlCommand(updateFlight, con))
            {
                command.Parameters.AddWithValue("@flightid", flight.FlightNo);
                command.Parameters.AddWithValue("@departureTime", flight.DepartureTime);
                command.Parameters.AddWithValue("@arrivalTime", flight.ArrivalTime);
                command.Parameters.AddWithValue("@departureLocation", flight.DepartureLocation);
                command.Parameters.AddWithValue("@destination", flight.Destination);
                command.Parameters.AddWithValue("@modelId", flight.Model);
                result = command.ExecuteNonQuery();
                
            }
            if (result == 0)
            {
                con.Dispose();
                return SuccessState.DBUnreachable
            }
            con.Dispose();
            return SuccessState.Success;
        }
    }
}
