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
        SeatDBIF seatdb;
        ModelDBIF modeldb;

        public FlightDB()
        {
            seatdb = new SeatDB();
            modeldb = new ModelDB();

            conStringBuilder.InitialCatalog = "dmaa0918_1071480";
            conStringBuilder.DataSource = "kraka.ucn.dk";
            conStringBuilder.UserID = "dmaa0918_1071480";
            conStringBuilder.Password = "Password1!";
        }

        private Flight objectBuilder(SqlDataReader dataReader)
        {
            //Builds a Flight object with data from the SqlDataReader
            Flight flight = new Flight(dataReader.GetString(5), dataReader.GetDateTime(1), 
                    dataReader.GetDateTime(2), dataReader.GetString(4), dataReader.GetString(3));
            flight.FlightNo = "" + dataReader.GetInt32(0);
            return flight;
        }

        public SuccessState DeleteFlight(int flightNo)
        {
            //Open connection and write query with placeholder value
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string deleteFlight = "DELETE FROM Flight WHERE flightId = @flightId";
            int result = 0;
            seatdb.DeleteSeatByFlightId(flightNo);
            using(SqlCommand command = new SqlCommand(deleteFlight, con))
            {
                //Replace placeholder value and execute query
                command.Parameters.AddWithValue("@flightId", flightNo);
                result = command.ExecuteNonQuery();
            }
            //Result is the number of rows that were changed in the database.
            //It should always return 1 if the query succeeds, as the flightNo is unique in the database.
            if (result == 0)
            {
                con.Dispose();
                return SuccessState.DBUnreachable;
            }
            con.Dispose();
            return SuccessState.Success;
        }

        public List<Flight> GetAllFlights()
        {
            //Open new connection and write query
            con = new SqlConnection(conStringBuilder.ConnectionString);
            List<Flight> flights = new List<Flight>();
            string getAllFlights = "SELECT * FROM Flight";
            con.Open();

            using(SqlCommand command = new SqlCommand(getAllFlights, con))
            {
                //Execute SqlDataReader build object.
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    flights.Add(objectBuilder(dataReader));
                }
            }
            con.Dispose();
            return flights;
        }

        public Flight GetFlightById(int flightNo)
        {
            //Open new connection and write query with placeholder value
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string getFlight = "SELECT * FROM Flight WHERE flightId = @flightId";
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(getFlight, con))
            {
                //Replace placeholder value and execute SqlDataReader and build object
                command.Parameters.AddWithValue("@flightId", flightNo);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    flight = objectBuilder(dataReader);
                }
                    
            }
            return flight;
        }

        //Inserts Flight into Database
        public int InsertFlight(Flight flight)
        {
            //Open connection and write query string with placeholder parameters
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string insertFlight = "INSERT INTO Flight (departureTime, arrivalTime, departureLocation," +
                "destination, modelId) VALUES(@departureTime, @arrivalTime, @departureLocation, @destination, @modelId)" +
                "SELECT SCOPE_IDENTITY()";
            int flightId = 0;
            using (SqlCommand command = new SqlCommand(insertFlight, con))
            {
                //Replace placeholder parameters and insert string. ExecuteScalar is used to return the flights ID
                command.Parameters.AddWithValue("@departureTime", flight.DepartureTime);
                command.Parameters.AddWithValue("@arrivalTime", flight.ArrivalTime);
                command.Parameters.AddWithValue("@departureLocation", flight.DepartureLocation);
                command.Parameters.AddWithValue("@destination", flight.Destination);
                command.Parameters.AddWithValue("@modelId", flight.Model);
                /*
                 * 
                 */
                var result = command.ExecuteScalar();
                string resultString = result.ToString();
                flightId = int.Parse(resultString);
            }
            //Inserts a number of seats based on numberOfSeats in the flights model
            
            Model model = modeldb.GetModelById(flight.Model);
            seatdb.InsertMultipleSeats(model.NumberOfSeats, flightId, 100.00);

            con.Dispose();
            return flightId;
        }

        public SuccessState UpdateFlight(int flightNo, Flight flight)
        {
            //Open new connection and write query wit placeholder values
            con = new SqlConnection(conStringBuilder.ConnectionString);
            con.Open();
            string updateFlight = "UPDATE Flight SET departureTime = @departureTime, arrivalTime = @arrivalTime" +
                "departureLocation = @departureLocation, destination = @destination, modelId = @modelId WHERE flightId = @flightId";
            int result = 0;
            using (SqlCommand command =new SqlCommand(updateFlight, con))
            {
                //Replace placeholder params with actual data and execute query.
                command.Parameters.AddWithValue("@flightid", flight.FlightNo);
                command.Parameters.AddWithValue("@departureTime", flight.DepartureTime);
                command.Parameters.AddWithValue("@arrivalTime", flight.ArrivalTime);
                command.Parameters.AddWithValue("@departureLocation", flight.DepartureLocation);
                command.Parameters.AddWithValue("@destination", flight.Destination);
                command.Parameters.AddWithValue("@modelId", flight.Model);
                result = command.ExecuteNonQuery();
                
            }
            //Return success state based on number of rows changed in DB
            if (result == 0)
            {
                con.Dispose();
                return SuccessState.DBUnreachable;
            }
            con.Dispose();
            return SuccessState.Success;
        }
    }
}
